using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.Model
{
    public class Paciente
    {
        public int idPaciente { get; set; }
        public string? NombrePac { get; set; }
        public string? ApellidoPac { get; set; }
        public string? RunPac { get; set; }
        public string? NacionalidadPac { get; set; }
        public string? Visa { get; set; }
        public string? SintomasPac { get; set; }
        public string? Genero { get; set; }
    }
}
