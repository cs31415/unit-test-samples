using System;

namespace UnitTestSamples
{
    public class ActivityData
    {
        private readonly ISqlClient _sqlClient;
        private readonly IConfig _config;

        public ActivityData(ISqlClient sqlClient, IConfig config)
        {
            _sqlClient = sqlClient;
            _config = config;
        }

        public void Save(string activity)
        {
            if (string.IsNullOrEmpty(activity))
            {
                throw new Exception("Can't save null or empty activity");
            }
            if (string.IsNullOrEmpty(_config.ActivityDbConnectionString))
            {
                throw new Exception("Invalid connection string passed");
            }

            var cmdText = $"exec sp_SaveActivity '{activity}'";
            _sqlClient.ExecuteNonQuery(_config.ActivityDbConnectionString, cmdText);
        }
    }
}
