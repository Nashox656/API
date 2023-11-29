using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.Model
{
        public class Medico
    {
        public int Id { get; set; }
        public string? NombreMed { get; set; }
        public string? ApellidoMed { get; set; }
        public string? RunMed { get; set; }
        public string? Eunacom { get; set; }
        public string? NacionalidadMed { get; set; }
        public string? Especialidad { get; set; }
        public DateTime Horarios { get; set; }
        public int TarifaHr { get; set; }
    }
    
}
