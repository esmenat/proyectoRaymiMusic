using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Favorito
    {
        [Key] public int Codigo { get; set; }

        //FK's
        public int UsuarioCodigo { get; set; }
        public int CancionCodigo { get; set; }

        //Navegation Properties
        public Usuario? Usuario { get; set; }
        public Cancion? Cancion { get; set; }

    }
}
