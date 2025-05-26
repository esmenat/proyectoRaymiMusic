using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RaymiMusic.Modelos
{
    public class Cancion
    {
        [Key] public int Codigo { get; set; }
        public string TituloCancion { get; set; }
        public DateInterval Duracion { get; set; }
        public string Ruta { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public DateOnly? FechaModificacion { get; set; }

        //FK'S
        public int ArtistaCodigo { get; set; }
        public int? AlbumCodigo { get; set; }

        //Navegation Properties
        public Artista? Artista { get; set; }
        public Album? Album { get; set; }
        public List<Reproduccion>? Reproducciones { get; set; }
        public List<CancionPlaylist>? CancionPlaylists { get; set; }
    }
}
