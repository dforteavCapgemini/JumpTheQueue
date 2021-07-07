using Microsoft.AspNetCore.Mvc.Testing;
using Devon4Net.Application.WebAPI;
using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Dto;
using System.Collections.Generic;
using System.IO;
using Devon4Net.WebAPI.Implementation.Domain.Entities;
using Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Cmd;

namespace Devon4Net.Test.JumTheQueue.IntegrationTest
{
    public class JumpThequequeIntegrationTest : IntegrationTest
    {

        public JumpThequequeIntegrationTest(ApiWebApplicationFactory fixture) : base(fixture) { }

        [Fact]
        public async Task CreateVisitor()
        {

            var result = await _client.PostResourceAsync("/JumpTheQueue/CreateVisitor", File.ReadAllText(@"inputdata\CreateVisitor.json"));
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Get_All_Visitors()
        {
            await _client.PostResourceAsync("/JumpTheQueue/CreateVisitor", File.ReadAllText(@"inputdata\CreateVisitor.json"));

            var visitors = await _client.GetAndDeserialize<List<VisitorDto>>("/JumpTheQueue/GetVisitors");
            visitors.Should().HaveCount(1);
        }

        [Fact]
        public async Task DeleteVisitorById()
        {
            var createVisitor = await _client.PostResourceAsync("/JumpTheQueue/CreateVisitor", File.ReadAllText(@"inputdata\CreateVisitor.json"));
            var visitor = JsonConvert.DeserializeObject<Visitor>(await createVisitor.Content.ReadAsStringAsync());

            var visitorDeleted = await _client.DeleteAsync($"/JumpTheQueue/DeleteVisitor?visitorId={visitor.VisitorId}");
            visitorDeleted.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateAccessCode()
        {
            var createVisitorResponse = await _client.PostResourceAsync("/JumpTheQueue/CreateVisitor", File.ReadAllText(@"inputdata\CreateVisitor.json"));
            var visitor = JsonConvert.DeserializeObject<Visitor>(await createVisitorResponse.Content.ReadAsStringAsync());

            AccessCodeCmd accessCode = new AccessCodeCmd
            {
                VisitorId = visitor.VisitorId,
                QueueId = 1
            };

            var result = await _client.PostResourceAsync("/JumpTheQueue/CreateAccessCode", JsonConvert.SerializeObject(accessCode));
            result.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task DeleteAccessCode()
        {
            var createVisitorResponse = await _client.PostResourceAsync("/JumpTheQueue/CreateVisitor", File.ReadAllText(@"inputdata\CreateVisitor.json"));
            var visitor = JsonConvert.DeserializeObject<Visitor>(await createVisitorResponse.Content.ReadAsStringAsync());

            AccessCodeCmd accessCode = new AccessCodeCmd
            {
                VisitorId = visitor.VisitorId,
                QueueId = 1
            };

            var accessCodeResponse = await _client.PostResourceAsync("/JumpTheQueue/CreateAccessCode", JsonConvert.SerializeObject(accessCode));
            var accessCodeCreated = JsonConvert.DeserializeObject<AccessCode>(await accessCodeResponse.Content.ReadAsStringAsync());


            var accessCodeDeleted = await _client.DeleteAsync($"/JumpTheQueue/DeleteAccessCode?accessCodeId={accessCodeCreated.AccessCodeId}");
            accessCodeDeleted.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
