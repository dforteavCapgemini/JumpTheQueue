using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Service;
using Devon4Net.WebAPI.Implementation.Data.Repositories;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Devon4Net.Test.JumTheQueue.UnitTest
{
    public abstract class UnitTest 
    {

        public Mock<IUnitOfWorkJumpTheQueue> IUnitOfWorkMock { get; private set; }
        public IJumpTheQueueService JumpTheQueueService { get; private set; }
        public Mock<IVisitorRepository> VisitorRepositoryMock { get; private set; }
        public Mock<IQueueRepository> QueueRepositoryMock { get; private set; }
        public Mock<IAccessCodeRepository> AccessCodeRepositoryMock { get; private set; }
        

        public List<Visitor> Visitors { get; private set; }
        public List<AccessCode> AccessCodes { get; private set; }
        public List<Queue> Queues { get; private set; }
        public AccessCode AccessCodeCreatedMocked { get; private set; }

        protected UnitTest()
        {
            ConfigureFakeData();
            ConfigureVisitorRepositoryMock();
            ConfigureQueueRepositoryMock();
            ConfigureAccessCodeRepositoryMock();
            ConfigureUnitOfWorkMock();
         
            JumpTheQueueService = new JumpTheQueueService(IUnitOfWorkMock.Object);
        }

        private void ConfigureFakeData()
        {
            Visitors = GetAllUsers().Where(v => v.UserType.Equals(true)).ToList();
            AccessCodes = GetAllAccessCodes();
            Queues = GetQueues();
            AccessCodeCreatedMocked = GetCreateAccessCode();
        }

        private void ConfigureUnitOfWorkMock()
        {
            IUnitOfWorkMock = new Mock<IUnitOfWorkJumpTheQueue>();
            IUnitOfWorkMock.Setup(m => m.SaveChanges(new CancellationToken())).ReturnsAsync(true);
            IUnitOfWorkMock.Setup(m => m.VisitorRepository).Returns(VisitorRepositoryMock.Object);
            IUnitOfWorkMock.Setup(m => m.AccessCodeRepository).Returns(AccessCodeRepositoryMock.Object);
            IUnitOfWorkMock.Setup(m => m.QueueRepository).Returns(QueueRepositoryMock.Object);
        }

        private void ConfigureAccessCodeRepositoryMock()
        {
            AccessCodeRepositoryMock = new Mock<IAccessCodeRepository>();

            AccessCodeRepositoryMock.Setup(accessCode => accessCode.GetAccessCodes(a => a.AccessCodeId > 0)).ReturnsAsync(AccessCodes);


            AccessCodeRepositoryMock.Setup(accessCode => accessCode.GetAccessCodeById(It.IsAny<int>()))
            .ReturnsAsync((int accessCodeId) =>
            {
                return AccessCodes.FirstOrDefault(accessCode => accessCode.AccessCodeId == accessCodeId);
            });

            AccessCodeRepositoryMock
             .Setup(users => users.DeleteAccessCode(It.IsAny<AccessCode>()))
             .Callback((AccessCode accessCodeTodDelete) => AccessCodes.Remove(accessCodeTodDelete));

            AccessCodeRepositoryMock.Setup(a => a.CreateAccessCode(It.IsAny<AccessCode>()))
           .ReturnsAsync(AccessCodeCreatedMocked);
        }

        private void ConfigureQueueRepositoryMock()
        {

            QueueRepositoryMock = new Mock<IQueueRepository>();
            QueueRepositoryMock.Setup(queue => queue.GetQueueById(It.IsAny<int>()))
            .ReturnsAsync((int queueId) =>
            {
                return Queues.FirstOrDefault(queue => queue.QueueId == queueId);
            });

            QueueRepositoryMock
                .Setup(queue => queue.UpdateQueue(It.IsAny<Queue>()))
                .Callback((Queue updatequeue) =>
                {
                    var oldqueue = Queues.FirstOrDefault(q => q.QueueId == updatequeue.QueueId);
                    oldqueue = updatequeue;

                });
        }

        private void ConfigureVisitorRepositoryMock()
        {
             VisitorRepositoryMock = new Mock<IVisitorRepository>();

            VisitorRepositoryMock
              .Setup(v => v.GetVisitors(v => v.UserType.Equals(true))).ReturnsAsync(Visitors);

            VisitorRepositoryMock.Setup(users => users.GetVisitorById(It.IsAny<int>()))
            .ReturnsAsync((int visitorId) =>
            {
                return Visitors.FirstOrDefault(visitor => visitor.VisitorId == visitorId);
            });

            VisitorRepositoryMock
                .Setup(users => users.DeleteVisitorById(It.IsAny<int>()))
                .Callback((int visitorTodDelete) => Visitors.Remove(Visitors.FirstOrDefault(v => v.VisitorId == visitorTodDelete)));
        }

        private  AccessCode GetCreateAccessCode()
        {
            return
                new AccessCode
                {
                    AccessCodeId = 11,
                    Visitor = Visitors.Single(v => v.VisitorId == 9),
                    DailyQueue = Queues.Single(q => q.QueueId == 1),
                    TicketNumber = 11,
                    CreationTime = DateTime.Now
                };
        }

        private List<AccessCode> GetAllAccessCodes()
        {

            return new List<AccessCode>()
            {
                new AccessCode { AccessCodeId = 1, TicketNumber = 1, CreationTime = DateTime.Now, StartTime = DateTime.Now, VisitorId = 1, DailyQueueId = 1},
                new AccessCode { AccessCodeId = 2, TicketNumber = 2, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 2, DailyQueueId = 1},
                new AccessCode { AccessCodeId = 3, TicketNumber = 3, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 3, DailyQueueId = 1, },
                new AccessCode { AccessCodeId = 4, TicketNumber = 4, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 4, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 5, TicketNumber = 5, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 5, DailyQueueId = 1},
                new AccessCode { AccessCodeId = 6, TicketNumber = 6, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 6, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 7, TicketNumber = 7, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 7, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 8, TicketNumber = 8, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 8, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 9, TicketNumber = 9, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 9, DailyQueueId = 1 },
                new AccessCode { AccessCodeId = 10, TicketNumber = 10, CreationTime = DateTime.Now, StartTime = new DateTime(2008, 01, 01, 0, 1, 01), VisitorId = 10, DailyQueueId = 1 }
            };
        }

        private List<Queue> GetQueues()
        {
            return new List<Queue>()
            {
                new Queue { QueueId = 1, Name = "Day2", Logo = "C:/logos/Day1Logo.png", CurrentNumber = 1, MinAttentionTime = new DateTime(1970, 01, 01, 0, 1, 0), Active = true, Customers = 9, AccessCodes = GetAllAccessCodes() }
            };
        }

        private List<Visitor> GetAllUsers()
        {
            return new List<Visitor>()
            {
                new Visitor { VisitorId = -1, Username = "mike@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = false, AcceptedTerms = true,     UserType = false },
                new Visitor { VisitorId = 1, Username = "peter@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 2, Username = "pablo@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 3, Username = "test1@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 4, Username = "test2@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 5, Username = "test3@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 6, Username = "test4@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 7, Username = "test5@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "1", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 8, Username = "test6@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 9, Username = "test7@mail.com",   Name = "test", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = true, AcceptedTerms = true,      UserType = true },
                new Visitor { VisitorId = 10, Username = "true@user.com",   Name = "testUser", Password = "123456789", PhoneNumber = "0", AcceptedCommercial = false, AcceptedTerms = true,   UserType = true }
            };
        }
    }
}
