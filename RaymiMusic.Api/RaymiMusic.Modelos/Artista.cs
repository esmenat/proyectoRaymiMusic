using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Artista
    {
        [Key] public int Codigo { get; set; }
        public string NombreArtistico { get; set; }
        public string Biografia { get; set; }

        //FK'S
        public int UsuarioCodigo { get; set; }

        //Navegation Properties
        public Usuario? Usuario { get; set; }
        public List<Album>? Albums { get; set; }
        public List<Cancion>? Canciones { get; set; }

    }
}
