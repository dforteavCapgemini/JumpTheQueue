using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service;
using Moq;
using System.Collections.Generic;
using Xunit;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using System.Linq;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Converters;
using FluentAssertions;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;
using System.Threading.Tasks;
using System;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Exceptions;

namespace Devon4Net.Test.JumTheQueue.UnitTest
{
    public class JumpThequeueUnitTest : UnitTest
    {
        public JumpThequeueUnitTest(){}

        #region Visitors

        [Fact]
        public async void CreateVisitor()
        {
            //Arrange
            VisitorCmd visitorCmd = new VisitorCmd
            {
                Name = "TestName",
                UserName = "TestUserName",
                Password = "TestPassword"
            };

            Visitor visitor = new Visitor
            {
                VisitorId = 11,
                Name = visitorCmd.Name,
                Username = visitorCmd.UserName,
                Password = visitorCmd.Password
            };

            var visitorRepositoryMock = new Mock<IVisitorRepository>();
            visitorRepositoryMock.Setup(v => v.Create(visitorCmd)).ReturnsAsync(visitor);
            IUnitOfWorkMock.Setup(m => m.VisitorRepository).Returns(visitorRepositoryMock.Object);
            IJumpTheQueueService jumpTheQueueService = new JumpTheQueueService(IUnitOfWorkMock.Object);

            //Act
            var result = await jumpTheQueueService.CreateVisitor(visitorCmd);

            //Assert
            result.Should().BeEquivalentTo(visitor);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(7)]
        public async void GetVisitorById(int visitorId)
        {
            // Arrange
            var expected = Visitors.FirstOrDefault(v => v.VisitorId == visitorId);

            //Act
            var result = await JumpTheQueueService.GetVisitorById(visitorId);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        public async void DeleteVisitorById(int visitorId)
        {
            // Arrange
            var expected = new List<Visitor>(Visitors);
            var visitorToRemove = expected.FirstOrDefault(v => v.VisitorId == visitorId);
            expected.Remove(visitorToRemove);

            //Act
            await JumpTheQueueService.DeleteVisitorById(visitorId);

            //Assert
            Visitors.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(99)]
        public async void DeleteVisitorByIdInvalidVisitor(int visitorId)
        {
            // Arrange
            var expected = new List<Visitor>(Visitors);
            var visitorToRemove = expected.FirstOrDefault(v => v.VisitorId == visitorId);
            expected.Remove(visitorToRemove);

            //Act
            Func<Task> act = async () => { await JumpTheQueueService.DeleteVisitorById(visitorId); };

            //Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task GetVisitors()
        {
            // Arrange
            var expected = Visitors.Select(VisitorConverter.ModelToDto);

            //Act
            var result = await JumpTheQueueService.GetVisitors();

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region Queue

        [Theory]
        [InlineData(1)]
        public async void GetQueueById(int queue)
        {
            // Arrange
            var expected = CopyQueue(Queues.FirstOrDefault());

            //Act
            await JumpTheQueueService.GetQueueById(queue);

            //Assert
            Queues.FirstOrDefault().Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public async Task DecreaseQueueCustomer(int accessCodeId)
        {
            // Arrange
            var accessCode = CopyAccessCode(AccessCodes.Single(v => v.AccessCodeId == accessCodeId));

            var queueExpected = CopyQueue(Queues.FirstOrDefault(q => q.QueueId == accessCode.DailyQueueId));
            queueExpected.Customers = queueExpected.AccessCodes.Count() - 1;
            queueExpected.CurrentNumber = queueExpected.AccessCodes
                                            .Where(a => a.AccessCodeId != accessCode.AccessCodeId)
                                            .OrderBy(a => a.TicketNumber)
                                            .FirstOrDefault()?.TicketNumber ?? 0;
            //Act
             await JumpTheQueueService.DecreaseQueueCustomer(accessCode); ;

            //Assert
            Queues.FirstOrDefault(q => q.QueueId == accessCode.DailyQueueId).Should().BeEquivalentTo(queueExpected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public async Task IncreaseQueueCustomer(int accessCodeId)
        {
            // Arrange
            var accessCode = CopyAccessCode(AccessCodes.Single(v => v.AccessCodeId == accessCodeId));

            var queueExpected = CopyQueue(Queues.FirstOrDefault(q => q.QueueId == accessCode.DailyQueueId));
            queueExpected.Customers = queueExpected.AccessCodes.Count() + 1;
            queueExpected.CurrentNumber = queueExpected.AccessCodes
                                                    .OrderBy(a => a.TicketNumber)
                                                    .FirstOrDefault().TicketNumber;


            //Act
            await JumpTheQueueService.IncreaseQueueCustomer(accessCode); ;

            //Assert
            Queues.FirstOrDefault(q => q.QueueId == accessCode.DailyQueueId).Should().BeEquivalentTo(queueExpected);
        }

        #endregion

        #region AccessCodes

        [Fact]
        public async void CreateAccessCodeInvalidVisitor()
        {
            //Arrange
            AccessCodeCmd accessCodeCmd = new AccessCodeCmd
            {
                VisitorId = 0,
                QueueId = 1
            };

            //Act
            Func<Task> act = async () => { await JumpTheQueueService.CreateAccessCode(accessCodeCmd); };

            //Assert
            await act.Should().ThrowAsync<JumpTheQueueException>();
        }

        [Fact]
        public async void CreateAccessCodeInvalidQueue()
        {
            //Arrange
            AccessCodeCmd accessCodeCmd = new AccessCodeCmd
            {
                VisitorId = 9,
                QueueId = 0
            };

            //Act
            Func<Task> act = async () => { await JumpTheQueueService.CreateAccessCode(accessCodeCmd); };

            //Assert
            await act.Should().ThrowAsync<JumpTheQueueException>();
        }

        [Fact]
        public async void CreateAccessCodeVisitorHaveAlreadyAccessCode()
        {
            //Arrange
            AccessCodeCmd accessCodeCmd = new AccessCodeCmd
            {
                VisitorId = 9,
                QueueId = 1
            };

            //Act
            Func<Task> act = async () => { await JumpTheQueueService.CreateAccessCode(accessCodeCmd); };

            //Assert
            await act.Should().ThrowAsync<JumpTheQueueException>();
        }


        [Fact]
        public async void CreateAccessCode()
        {
            //Arrange
            AccessCodeCmd accessCodeCmd = new AccessCodeCmd
            {
                VisitorId = 9,
                QueueId = 1
            };

            //Act Borramos un AccessCode Para permitir su inserción en 1º lugar
            await JumpTheQueueService.DeleteAccessCodeById(9);
            var result = await JumpTheQueueService.CreateAccessCode(accessCodeCmd);

            //Assert
            result.Should().BeEquivalentTo(AccessCodeCreatedMocked);
        }

        [Fact]
        public async Task GetAccessCodes()
        {
            // Arrange
            var expected = new List<AccessCode>(AccessCodes);

            //Act
            var result = await JumpTheQueueService.GetAccessCodes(a => a.AccessCodeId > 0);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(9)]
        public async void DeleteAccessCodeById(int accessCodeId)
        {
            // Arrange
            List<AccessCode> expected = new List<AccessCode>(AccessCodes);
            var accessCodToRemove = expected.FirstOrDefault(a => a.AccessCodeId == accessCodeId);
            expected.Remove(accessCodToRemove);

            //Act
            await JumpTheQueueService.DeleteAccessCodeById(accessCodeId);

            //Assert
            AccessCodes.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(22)]
        public async void DeleteAccessCodeByIdInvalidId(int accessCodeId)
        {
            // Arrange
            List<AccessCode> expected = new List<AccessCode>(AccessCodes);
            var accessCodToRemove = expected.FirstOrDefault(a => a.AccessCodeId == accessCodeId);
            expected.Remove(accessCodToRemove);


            //Act
            Func<Task> act = async () => { await JumpTheQueueService.DeleteAccessCodeById(accessCodeId); };

            //Assert
            await act.Should().ThrowAsync<JumpTheQueueException>();
        }


        #endregion

        private Queue CopyQueue(Queue queueOriginal)
        {
            return new Queue
            {
                QueueId = queueOriginal.QueueId,
                CurrentNumber = queueOriginal.CurrentNumber,
                AccessCodes = queueOriginal.AccessCodes,
                Active = queueOriginal.Active,
                AttentionTime = queueOriginal.AttentionTime,
                Customers = queueOriginal.Customers,
                Logo = queueOriginal.Logo,
                MinAttentionTime = queueOriginal.MinAttentionTime,
                Name = queueOriginal.Name,
                Password = queueOriginal.Password
            };
        }

        private AccessCode CopyAccessCode(AccessCode accessCode)
        {
            return new AccessCode
            {
                AccessCodeId = accessCode.AccessCodeId,
                TicketNumber = accessCode.TicketNumber,
                CreationTime = accessCode.CreationTime,
                StartTime = accessCode.StartTime,
                VisitorId = accessCode.VisitorId,
                DailyQueueId = accessCode.DailyQueueId,
                DailyQueue = Queues.FirstOrDefault(q => q.QueueId == accessCode.DailyQueueId)
            };
        }
    }
    
}
