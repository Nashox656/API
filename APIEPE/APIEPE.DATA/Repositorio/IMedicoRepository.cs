using APIEPE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.DATA.Repositorio
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllMedicos();
        Task<Medico> GetDetails(int id);
        Task<bool> InsertMedico(Medico mediico);
        Task<bool> UpdateMedico(Medico mediico);
        Task<bool> DeleteMedico(Medico medico);

    }
}
