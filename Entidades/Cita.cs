using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string? Lugar { get; set; }
        public string? Estado { get; set; } 
        public int IdPaciente { get; set; }
        public int IdTipoCita { get; set; }
        public int IdSucursal { get; set; }
    }
}
