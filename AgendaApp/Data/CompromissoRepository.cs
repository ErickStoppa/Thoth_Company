using Dapper;
using System.Collections.Generic;
using AgendaApp.Models;

namespace AgendaApp.Data
{
    public class CompromissoRepository
    {
        public IEnumerable<Compromisso> ListarPorUsuario(int usuarioId)
        {
            using (var db = Database.GetConnection())
            return db.Query<Compromisso>(
                "SELECT * FROM Compromissos WHERE UsuarioId = @Id ORDER BY DataHora",
                new { Id = usuarioId }
            );
        }

        public void Inserir(Compromisso c)
        {
            const string sql = @"
                INSERT INTO Compromissos (UsuarioId, Titulo, Descricao, DataHora)
                VALUES (@UsuarioId, @Titulo, @Descricao, @DataHora)";
            using (var db = Database.GetConnection())
            db.Execute(sql, c);
        }

        public void Atualizar(Compromisso c)
        {
            const string sql = @"
                UPDATE Compromissos
                SET Titulo = @Titulo, Descricao = @Descricao, DataHora = @DataHora
                WHERE Id = @Id";
            using (var db = Database.GetConnection())
            db.Execute(sql, c);
        }

        public void Remover(int id)
        {
            using (var db = Database.GetConnection())
            db.Execute("DELETE FROM Compromissos WHERE Id = @Id", new { Id = id });
        }
    }
}
