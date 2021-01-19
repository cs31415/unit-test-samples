using System;
using Moq;
using Xunit;

namespace UnitTestSamples.Tests
{
    public class ActivityDataTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Save_InvalidActivity_RaisesException(string activity)
        {
            // Arrange
            var sqlClient = Mock.Of<ISqlClient>();
            var config = Mock.Of<IConfig>();
            var activityData = new ActivityData(sqlClient, config);

            // Act, Assert
            Assert.Throws<Exception>(() => activityData.Save(activity));
        }

        [Fact]
        public void Save_ValidActivity_UpdatesDatabase()
        {
            // Arrange
            var sqlClient = Mock.Of<ISqlClient>();
            Mock.Get(sqlClient)
                .Setup(m => m.ExecuteNonQuery(It.IsAny<string>(), It.IsAny<string>()));

            var config = Mock.Of<IConfig>();
            Mock.Get(config)
                .SetupGet(p => p.ActivityDbConnectionString)
                .Returns("valid-connection-string");
            
            var activityData = new ActivityData(sqlClient, config);

            // Act

            activityData.Save("Create a compost pile");

            // Assert
            Mock.Get(sqlClient)
                .Verify(m => m.ExecuteNonQuery(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Save_InvalidConnectionString_RaisesException()
        {
            // Arrange
            var sqlClient = Mock.Of<ISqlClient>();
            var config = Mock.Of<IConfig>();
            string invalidConnectionString = string.Empty;
            Mock.Get(config)
                .SetupGet(p => p.ActivityDbConnectionString)
                .Returns(invalidConnectionString);

            var activityData = new ActivityData(sqlClient, config);

            // Act, Assert
            Assert.Throws<Exception>(() => activityData.Save("Create a compost pile"));
        }
    }
}
