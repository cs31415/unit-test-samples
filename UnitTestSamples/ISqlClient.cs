namespace UnitTestSamples
{
    public interface ISqlClient
    {
        void ExecuteNonQuery(string connectionString, string cmdText);
    }
}