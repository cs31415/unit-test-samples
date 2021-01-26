using System;
using Moq;
using Xunit;

namespace UnitTestSamples.Tests
{
    public class RefactoredActivityDataTests
    {
        private readonly MockSqlClient _mockSqlClient;
        private readonly MockConfig _mockConfig;

        public RefactoredActivityDataTests()
        {
            _mockSqlClient = new MockSqlClient();
            _mockConfig = new MockConfig();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Save_InvalidActivity_RaisesException(string activity)
        {
            // Arrange
            var activityData = new ActivityData(_mockSqlClient.Object, _mockConfig.Object);

            // Act, Assert
            Assert.Throws<Exception>(() => activityData.Save(activity));
        }

        [Fact]
        public void Save_ValidActivity_UpdatesDatabase()
        {
            // Arrange
            _mockSqlClient.Setup_ExecuteNonQuery();
            _mockConfig.SetupGet_ActivityDbConnectionString("valid-connection-string");
            
            var activityData = new ActivityData(_mockSqlClient.Object, _mockConfig.Object);

            // Act
            activityData.Save("Create a compost pile");

            // Assert
            _mockSqlClient.Verify_ExecuteNonQuery_Called(Times.Once);
        }

        [Fact]
        public void Save_InvalidConnectionString_RaisesException()
        {
            // Arrange
            _mockConfig.SetupGet_ActivityDbConnectionString(string.Empty);

            var activityData = new ActivityData(_mockSqlClient.Object, _mockConfig.Object);

            // Act, Assert
            Assert.Throws<Exception>(() => activityData.Save("Create a compost pile"));
        }
    }
}
