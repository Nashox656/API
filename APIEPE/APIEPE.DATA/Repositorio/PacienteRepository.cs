using APIEPE.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEPE.DATA.Repositorio
{
    public class PacienteRepository : IPaciente
    {
        private readonly MySQLConfiguration _connectionString;
        public PacienteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteMedico(Paciente paciente)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM medico WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = paciente.idPaciente });

            return result > 0;
        }

        public Task<IEnumerable<Paciente>> GetAllPaciente()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM paciente";

            return db.QueryAsync<Paciente>(sql, new { });
        }

        public Task<Paciente> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT idPaciente, NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed, Especialidad, Horarios, TarifaHr FROM medico WHERE id= @Id";

            return db.QueryFirstOrDefaultAsync<Paciente>(sql, new { Id = id });
        }

        public async Task<bool> InsertPaciente(Paciente paciente)
        {
            {
                var db = dbConnection();

                var sql = @"INSERT INTO paciente(NombrePac, ApellidoPac, RunPac, NacionalidadPac,Visa,
                       SintomasPac, Genero) VALUES (@NombrePac, @ApellidoPac, @RunPac, @NacionalidadPac, @Visa,@SintomasPac,@Genero)";

                var result = await db.ExecuteAsync(sql, new
                {
                    paciente.NombrePac,
                    paciente.ApellidoPac,
                    paciente.RunPac,
                    paciente.NacionalidadPac,
                    paciente.SintomasPac,
                    paciente.Visa,
                    paciente.Genero
                });
                return result > 0;
            }
        }

        public async  Task<bool> UpdatePaciente(Paciente paciente)
        {
            var db = dbConnection();

            var sql = @"UPDATE paciente SET NombrePac = @NombrePac, ApellidoPac = @ApellidoPac, RunPac = @RunPac, NacionalidadPac = @NacionalidadPac,Visa = @Visa,
                       SintomasPac = @SintomasPac, Genero = @Genero WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new
            {
                paciente.NombrePac,
                paciente.ApellidoPac,
                paciente.RunPac,
                paciente.NacionalidadPac,
                paciente.SintomasPac,
                paciente.Visa,
                paciente.Genero
            });
            return result > 0;
        }

        public async Task<bool> DeletePaciente(Paciente paciente)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM paciente WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = paciente.idPaciente });

            return result > 0;
        }
    }
    
}
