using Dapper;
using System.Linq;
using AgendaApp.Models;

namespace AgendaApp.Data
{
    public class UsuarioRepository
    {
        public Usuarios ObterPorNome(string nome)
        {
            using (var db = Database.GetConnection())
            {
                return db.Query<Usuarios>(
                    "SELECT * FROM Usuarios WHERE Usuario = @Usuario",
                    new { Usuario = nome }
                ).FirstOrDefault();
            }
        }

        public void Inserir(Usuarios u)
        {
            const string sql = @"
                    INSERT INTO Usuarios (Usuario, SenhaHash, Salt)
                    VALUES (@Usuario, @SenhaHash, @Salt)";
            using (var db = Database.GetConnection())
            {
                db.Execute(sql, u);
            }
        }
    }
}
