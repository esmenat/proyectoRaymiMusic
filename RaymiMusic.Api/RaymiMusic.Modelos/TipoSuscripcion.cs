using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class TipoSuscripcion
    {
        [Key] public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioMensual { get; set; }

        //Navigation Properties
        public List<Suscripcion>? suscripciones { get; set; }
    }
}
