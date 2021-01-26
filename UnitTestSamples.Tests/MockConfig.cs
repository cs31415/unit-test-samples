using Moq;

namespace UnitTestSamples.Tests
{
    public class MockConfig : Mock<IConfig>
    {
        public void SetupGet_ActivityDbConnectionString(string connectionString)
        {
            this.SetupGet(p => p.ActivityDbConnectionString)
                .Returns(connectionString);
        }
    }
}
