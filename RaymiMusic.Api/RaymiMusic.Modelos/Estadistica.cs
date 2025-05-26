using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Estadistica
    {
        [Key] public int Codigo { get; set; }
        public int ReproduccionesTotales { get; set; }
        public int FavoritosTotales { get; set; }

        //FK'S
        public int CancionCodigo { get; set; }

        //Navegation Properties
        public Cancion? Cancion { get; set; }
    }
}
