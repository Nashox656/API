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
    public class MedicoRepository : IMedicoRepository
    {
            private readonly MySQLConfiguration _connectionString;
            public MedicoRepository (MySQLConfiguration connectionString)
            {
                _connectionString = connectionString;
            }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        
        public async Task<bool> DeleteMedico(Medico medico)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM medico WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new {Id = medico.Id});

            return result > 0;
        }

        public Task<IEnumerable<Medico>> GetAllMedicos()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM medico";

            return db.QueryAsync<Medico>(sql, new {});
        }

        public async Task<bool> InsertMedico(Medico mediico)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO medico(NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed,
                       Especialidad, Horarios, TarifaHr) VALUES ( @NombreMed, @ApellidoMed, @RunMed, @Eunacom, @NacionalidadMed, @Especialidad, @Horarios, @TarifaHr)";

            var result = await db.ExecuteAsync(sql, new 
            {
                mediico.NombreMed,
                mediico.ApellidoMed,
                mediico.RunMed,
                mediico.Eunacom,
                mediico.NacionalidadMed,
                mediico.Especialidad,
                mediico.Horarios,
                mediico.TarifaHr });
            return result > 0;
        }

        public async Task<bool> UpdateMedico(Medico mediico)
        {
            var db = dbConnection();

            var sql = @"UPDATE medico
                       SET idMedico = @idMedico, NombreMed = @NombreMed, ApellidoMed = @ApellidoMed, RunMed = @RunMed, Eunacom = @Eunacom, NacionalidadMed = @NacionalidadMed,
                       Especialidad = @Especialidad, Horarios = @Horarios, TarifaHr = @TarifaHr WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new
            {
                mediico.Id,
                mediico.NombreMed,
                mediico.ApellidoMed,
                mediico.RunMed,
                mediico.Eunacom,
                mediico.NacionalidadMed,
                mediico.Especialidad,
                mediico.Horarios,
                mediico.TarifaHr
            });
            return result > 0;
        }

        public Task<Medico> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT idMedico, NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed, Especialidad, Horarios, TarifaHr FROM medico WHERE id= @Id";

            return db.QueryFirstOrDefaultAsync<Medico>(sql, new { Id = id});
        }
    }
}
