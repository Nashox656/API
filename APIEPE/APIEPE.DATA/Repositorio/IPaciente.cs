using APIEPE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.DATA.Repositorio
{
    public interface IPaciente
    {
        Task<IEnumerable<Paciente>> GetAllPaciente();
        Task<Paciente> GetDetails(int id);
        Task<bool> InsertPaciente(Paciente paciente);
        Task<bool> UpdatePaciente(Paciente paciente);
        Task<bool> DeletePaciente(Paciente paciente);
    }
}
