using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Rol
    {
        [Key] public int Codigo { get; set; }
        public string NombreRol { get; set; }

        //Navegation Properties
        public List<Usuario>? Usuarios { get; set; }
    }
}
