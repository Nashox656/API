using APIEPE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.DATA.Repositorio
{
    public interface IReserva
    {
        Task<IEnumerable<Reserva>> GetAllReserva();
        Task<Reserva> GetDetails(int id);
        Task<bool> InsertReserva(Reserva reserva);
        Task<bool> UpdateReserva(Reserva reserva);
        Task<bool> DeleteReserva(Reserva reserva);
    }
}
