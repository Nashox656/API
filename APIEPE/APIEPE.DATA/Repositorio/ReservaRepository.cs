using APIEPE.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.DATA.Repositorio
{
    public class ReservaRepository : IReserva
    {
        private readonly MySQLConfiguration _connectionString;
        public ReservaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public Task<bool> DeleteReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reserva>> GetAllReserva()
        {
            throw new NotImplementedException();
        }

        public Task<Reserva> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
