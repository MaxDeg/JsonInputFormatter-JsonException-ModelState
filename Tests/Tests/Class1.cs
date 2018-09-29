using JsonInputFormatter_JsonException_ModelState;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Class1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public Class1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test_ModelState()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var content = new StringContent("{ 'id': 2 }", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/echo", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_ModelState_Error()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var content = new StringContent("{ }", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/echo", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"id\":[\"Required property 'id' not found in JSON.Path '', line 1, position 3.\"]}", responseContent);
        }

        [Fact]
        public async Task Test_ModelState_Error_Url_Encoding()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var content = new FormUrlEncodedContent(new Dictionary<string, string>());
            var response = await client.PostAsync("/echo2", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("{\"Id\":[\"A value for the 'Id' property was not provided.\"]}", responseContent);
        }
    }
}
