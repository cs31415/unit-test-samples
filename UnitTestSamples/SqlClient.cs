using System.Data;
using System.Data.SqlClient;

namespace UnitTestSamples
{
    public class SqlClient : ISqlClient
    {
        public void ExecuteNonQuery(string connectionString, string cmdText)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
