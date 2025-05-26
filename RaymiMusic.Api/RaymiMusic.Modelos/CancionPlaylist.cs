using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class CancionPlaylist
    {
        [Key] public int Codigo { get; set; }
        public int Orden { get; set; }

        //FK'S
        public int CancionCodigo { get; set; }
        public int PlaylistCodigo { get; set; }

        //Navegation Properties
        public Cancion? Cancion { get; set; }
        public Playlist? Playlists { get; set; }
    }
}
