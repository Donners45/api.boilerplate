using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using test.integration.Base;
using Xunit;

namespace test.integration
{
    public class UnitTest1 : IClassFixture<TestFixture<api.Startup>>
    {
        public UnitTest1(TestFixture<api.Startup> fixture)
        {
            Client = fixture.Client;
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task Test1()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            Assert.Equal("Test response", content);
            Assert.False(response.Headers.Contains("Server"), "Should not contain server header");
        }
    }
}
