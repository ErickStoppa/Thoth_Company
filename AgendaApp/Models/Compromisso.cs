using System;

namespace AgendaApp.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
