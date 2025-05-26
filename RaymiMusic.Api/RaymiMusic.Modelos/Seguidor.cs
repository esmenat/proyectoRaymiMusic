using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Seguidor
    {
        [Key] public int Codigo { get; set; }  
        public int SeguidorCodigo { get; set; }
        public Usuario? SeguidorUsuario { get; set; }
        public int SeguidoCodigo { get; set; }
        public Usuario? SeguidoUsuario { get; set; }
    }
}
