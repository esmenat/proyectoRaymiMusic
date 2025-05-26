using System.ComponentModel.DataAnnotations;

namespace RaymiMusic.Modelos
{
    public class Usuario
    {
        [Key] public int Codigo { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateOnly FechaNac { get; set; }
        public string Genero { get; set; }
        public DateOnly FechaRegistro { get; set; }
        public string Region { get; set; }
        public string? FotoPerfilURL { get; set; }

        //FK's
        public int RolCodigo { get; set; }
        public int SuscripcionCodigo { get; set; }

        //Navigation Properties
        public Rol? Rol { get; set; }
        public Suscripcion? Suscripcion { get; set; }
        public List<Playlist>? Playlists { get; set; }
        public List<Reproduccion>? Reproducciones { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
