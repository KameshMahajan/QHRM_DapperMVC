using Dapper;
using System.Data;
using System.Data.SqlClient;
 

namespace DapperMVC.Models
{
    public static class DapperOrm
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DapperDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
    public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                return (T)Convert.ChangeType(sqlcon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ReturnSingle<T>(string storedProcedureName, DynamicParameters parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                return connection.QuerySingleOrDefault<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }


        internal static void ExecuteWithoutReturn(string v, object parameters)
        {
            throw new NotImplementedException();
        }
    }
}
