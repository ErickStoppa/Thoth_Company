using System.Data;
using System.Data.SqlClient;

namespace AgendaApp.Data
{
    public static class Database
    {
        // Se você usou LocalDB:
        private const string ConnString =
            "Server=(localdb)\\MSSQLLocalDB;Database=AgendaDB;Trusted_Connection=True;";

        // Ou se estiver usando sua instância nomeada:
        // private const string ConnString =
        //     "Server=ERICK-PC\\SQLEXPRESS;Database=AgendaDB;User Id=sa;Password=SuaSenha;";

        public static IDbConnection GetConnection()
            => new SqlConnection(ConnString);
    }
}
