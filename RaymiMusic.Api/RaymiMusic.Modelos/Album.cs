using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Album
    {
        [Key] public int Codigo { get; set; }
        public string Titulo { get; set; }
        public DateOnly FechaLanzamiento { get; set; }
        public string Genero { get; set; }
        public DateOnly? FechaModificacion { get; set; }

        //FK'S
        public int ArtistaCodigo { get; set; }

        //Navegation Properties
        public Artista? Artista { get; set; }
        public List<Cancion>? Canciones { get; set; }

    }
}
