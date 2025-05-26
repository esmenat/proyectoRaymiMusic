using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Pago
    {
        [Key] public int Codigo { get; set; }
        public DateOnly Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }

        //FK's
        public int SuscripcionCodigo { get; set; }

        //Navigation Properties
        public Suscripcion? Suscripcion { get; set; }
    }
}
