using Xunit;

namespace UnitTestSamples.Tests
{
    public class MultiMapTests
    {
        [Fact]
        public void Add_KeyDoesNotExist_AddsValueToNewListForKey()
        {
            // Arrange
            var multiMap = new MultiMap<string, string>();

            // Act
            var key = "yellow";
            var value = "Sun";
            multiMap.Add(key, value);

            // Assert
            Assert.True(multiMap.ContainsKey(key) && multiMap[key].Contains(value));
        }

        [Theory]
        [InlineData("yellow", true)]
        [InlineData("red", false)]
        public void ContainsKey_VariousKeys_ReturnsStatus(string key, bool expectedStatus)
        {
            // Arrange
            var multiMap = new MultiMap<string, string>();

            // Act
            multiMap.Add("yellow", "Sun");

            // Assert
            Assert.True(multiMap.ContainsKey(key) == expectedStatus);
        }
    }
}
