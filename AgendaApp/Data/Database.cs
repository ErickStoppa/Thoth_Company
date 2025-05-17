using System.Data;
using System.Data.SqlClient;

namespace AgendaApp.Data
{
    public static class Database
    {
        private const string ConnString =
            "Server=ERICK-PC;Database=AgendaDB;User Id=sa;Password=Teste123;";
        public static IDbConnection GetConnection()
            => new SqlConnection(ConnString);
    }
}
