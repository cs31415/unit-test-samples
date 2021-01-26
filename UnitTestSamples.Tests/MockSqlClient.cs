using System;
using Moq;

namespace UnitTestSamples.Tests
{
    public class MockSqlClient : Mock<ISqlClient>
    {
        public void Setup_ExecuteNonQuery()
        {
            this.Setup(m => m.ExecuteNonQuery(It.IsAny<string>(), It.IsAny<string>()));
        }

        public void Verify_ExecuteNonQuery_Called(Func<Times> times)
        {
            this.Verify(m => m.ExecuteNonQuery(It.IsAny<string>(), It.IsAny<string>()), times);
        }
    }
}
