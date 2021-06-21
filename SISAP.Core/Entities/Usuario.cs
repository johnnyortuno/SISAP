namespace SISAP.Core.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int Rol { get; set; }
        public int Estado { get; set; }
    }
}
