using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class Suscripcion
    {
        [Key] public int Codigo { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public bool Activa { get; set; }

        //FK'S
        public int TipoSuscripcionCodigo { get; set; }

        //Navegation Properties
        public TipoSuscripcion? TipoSuscripcion { get; set; }
        public List<Pago>? Pagos { get; set; }
        public List<Usuario>? Usuarios { get; set; } 


    }
}
