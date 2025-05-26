using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Playlist
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool EsPublica { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public DateOnly? FechaModificacion { get; set; }

        //FK'S
        public int UsuarioCodigo { get; set; }

        //Navegation Properties
        public Usuario? Usuario { get; set; }
        public List<CancionPlaylist>? CancionesPlaylists { get; set; }
    }
}
