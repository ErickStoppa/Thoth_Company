namespace AgendaApp.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] Salt { get; set; }
    }
}
