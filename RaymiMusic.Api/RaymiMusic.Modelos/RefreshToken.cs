using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaymiMusic.Modelos
{
    public class RefreshToken
    {
        [Key] public int Codigo { get; set; }
        public string Token { get; set; }
        public DateTime FechaExpiracion { get; set; }
        
        //FK's
        public int UsuarioCodigo { get; set; }
        
        //Navegation Properties
        public Usuario? Usuario { get; set; }
    }
}
