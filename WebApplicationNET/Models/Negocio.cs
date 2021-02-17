
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNET.Models
{
    public class Negocio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DayOfWeek DiaDeLaSemana { get; set; }
        public string HorarioApertura { get; set; }
        public string HorarioCierre { get; set; }

    }
}
