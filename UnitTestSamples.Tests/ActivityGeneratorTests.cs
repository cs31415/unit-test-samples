using System;
using System.Net;
using System.Net.Http;
using Moq;
using Xunit;

namespace UnitTestSamples.Tests
{
    public class ActivityGeneratorTests
    {
        [Fact]
        public void GetActivity_ValidResponse_ReturnsActivity()
        {
            // Arrange

            // This is the json response we want the API to return
            var responseJson = @"{
                ""activity"": ""Make a new friend"",
                ""type"": ""social"",
                ""participants"": 1,
                ""price"": 0,
                ""link"": """",
                ""key"": ""1000000"",
                ""accessibility"": 0
            }";

            // This is the HTTP response message class we want the API to
            // return
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(responseJson);
            
            // Here, we setup a mock ApiClient instance and program it to 
            // return our canned HTTP response above.
            var apiClient = Mock.Of<IApiClient>();
            Mock.Get(apiClient)
                .Setup(m => m.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(httpResponseMessage);
            
            // We instantiate the SUT and pass in the mock dependency
            var activityGenerator = new ActivityGenerator(apiClient);

            // Act
            var activity = activityGenerator.GetActivity();

            // Assert
            Assert.True(!string.IsNullOrEmpty(activity));
        }

        [Fact]
        public void GetActivity_APIThrowsException_RaisesException()
        {
            // Arrange
            // Here, we setup a mock ApiClient instance and program it to 
            // throw a WebException.
            var apiClient = Mock.Of<IApiClient>();
            Mock.Get(apiClient)
                .Setup(m => m.GetAsync(It.IsAny<string>()))
                .ThrowsAsync(new WebException("network error", WebExceptionStatus.ConnectFailure));

            // We instantiate the SUT and pass in the mock dependency
            var activityGenerator = new ActivityGenerator(apiClient);

            // Act
            var ex = Assert.Throws<AggregateException>(()=> activityGenerator.GetActivity());

            // Assert
            Assert.IsType<WebException>(ex.GetBaseException());

        }

        [Fact]
        public void GetActivity_500Response_ReturnsNull()
        {
            // Arrange

            // This is the HTTP response message class we want the API to
            // return
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            // Here, we setup a mock ApiClient instance and program it to 
            // return our canned HTTP response above.
            var apiClient = Mock.Of<IApiClient>();
            Mock.Get(apiClient)
                .Setup(m => m.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(httpResponseMessage);

            // We instantiate the SUT and pass in the mock dependency
            var activityGenerator = new ActivityGenerator(apiClient);

            // Act
            var activity = activityGenerator.GetActivity();

            // Assert
            Assert.True(string.IsNullOrEmpty(activity));
        }

        [Fact]
        public void GetActivity__CallsActivityAPI()
        {
            // Arrange

            // This is the HTTP response message class we want the API to
            // return
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);

            // Here, we setup a mock ApiClient instance and program it to 
            // return our canned HTTP response above.
            var apiClient = Mock.Of<IApiClient>();
            Mock.Get(apiClient)
                .Setup(m => m.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(httpResponseMessage);

            // We instantiate the SUT and pass in the mock dependency
            var activityGenerator = new ActivityGenerator(apiClient);

            // Act
            var activity = activityGenerator.GetActivity();

            // Assert
            Assert.True(string.IsNullOrEmpty(activity));
        }
    }
}
