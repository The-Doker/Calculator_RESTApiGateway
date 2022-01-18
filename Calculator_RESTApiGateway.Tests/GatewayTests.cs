using Calculator_RESTApiGateway.Controllers;
using Calculator_RESTApiGateway.Models;
using Newtonsoft.Json;
using System;
using Xunit;

namespace Calculator_RESTApiGateway.Tests
{
    public class GatewayTests
    {
        [Fact]
        public async void CorrectDataFromPOST()
        {
            // Arrange
            var controller = new CalculateController();
            var request = CreateTestRequest();
            var expectedReply = CreateExpectedReply();

            // Act
            var reply = await controller.Post(request);
            var deserializedReply = JsonConvert.DeserializeObject<Reply>(reply);

            // Assert
            Assert.Equal(expectedReply.Success, deserializedReply.Success);
            Assert.Equal(expectedReply.Error, deserializedReply.Error);
            Assert.Equal(expectedReply.Results[0].CalculateResut, deserializedReply.Results[0].CalculateResut);
            Assert.Equal(expectedReply.Results[1].CalculateResut, deserializedReply.Results[1].CalculateResut);
            Assert.Equal(expectedReply.Results[2].CalculateResut, deserializedReply.Results[2].CalculateResut);
            Assert.Equal(expectedReply.Results[3].CalculateResut, deserializedReply.Results[3].CalculateResut);
            Assert.Equal(expectedReply.Results[0].Description, deserializedReply.Results[0].Description);
            Assert.Equal(expectedReply.Results[1].Description, deserializedReply.Results[1].Description);
            Assert.Equal(expectedReply.Results[2].Description, deserializedReply.Results[2].Description);
            Assert.Equal(expectedReply.Results[3].Description, deserializedReply.Results[3].Description);
        }

        private Request CreateTestRequest()
        {
            var operationArray = new int[4]
            {
                0, 1, 2, 3
            };
            var firstParameter = new Parameters()
            {
                Name = "ObjectA",
                Value = 10.0M
            };
            var secondParameter = new Parameters()
            {
                Name = "ObjectB",
                Value = 20.0M
            };
            Parameters[] parameters = new Parameters[2]
            {
                firstParameter, secondParameter
            };
            return new Request()
            {
                Type = operationArray,
                Parameters = parameters
            };
        }
        private Reply CreateExpectedReply()
        {
            Result sumResult = new Result()
            {
                Type = 0,
                CalculateResut = 30.0M,
                Description = "ObjectA + ObjectB"
            };
            Result subResult = new Result()
            {
                Type = 1,
                CalculateResut = -10.0M,
                Description = "ObjectA - ObjectB"
            };
            Result mulResult = new Result()
            {
                Type = 2,
                CalculateResut = 200.0M,
                Description = "ObjectA * ObjectB"
            };
            Result divResult = new Result()
            {
                Type = 3,
                CalculateResut = 0.5M,
                Description = "ObjectA / ObjectB"
            };
            Result[] results = new Result[4]
            {
                sumResult, subResult, mulResult, divResult
            };
            return new Reply()
            {
                Success = true,
                Error = "",
                Results = results
            };
            
        }
    }
}
