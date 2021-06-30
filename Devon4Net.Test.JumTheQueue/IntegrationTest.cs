using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Respawn;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Devon4Net.Test.JumTheQueue
{
    public abstract class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly Checkpoint _checkpoint = new Checkpoint
        {
            TablesToInclude = new[] { "Visitors" },
            WithReseed = true
        };

        protected readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public IntegrationTest(ApiWebApplicationFactory fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();
            _checkpoint.Reset(_factory.Configuration.GetConnectionString("JumpTheQueue_INT")).Wait();
        }
    }

    public static class Extensions
    {

        private const string MediaTypeJson = "application/json";

        public static async Task<T> GetAndDeserialize<T>(this HttpClient client, string requestUri)
        {
             return await client.GetFromJsonAsync<T>(requestUri);
        }

        public static async Task<HttpResponseMessage> PostResourceAsync(this HttpClient client, string url, string postContent)
        {
            return await client.PostAsync(url, new StringContent(postContent, Encoding.UTF8, MediaTypeJson));
        }
    }
}
