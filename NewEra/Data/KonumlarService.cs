using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NewEra.Data
{
    public class KonumlarService : IKonumlarService
    {
        // Database connection
        private readonly SqlConnectionConfiguration _configuration;
        public KonumlarService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Add (create) a Konumlar table row (SQL Insert)
        // This only works if you're already created the stored procedure.
        public async Task<bool> KonumlarInsert(Konumlar konumlar)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Bina", konumlar.Bina, DbType.String);
                parameters.Add("Kat", konumlar.Kat, DbType.String);
                parameters.Add("Konum", konumlar.Konum, DbType.String);

                // Stored procedure method
                await conn.ExecuteAsync("spKonumlar_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
        // Get a list of konumlar rows (SQL Select)
        // This only works if you're already created the stored procedure.
        public async Task<IEnumerable<Konumlar>> KonumlarGetAll()
        {
            IEnumerable<Konumlar> konumlar;
            using (var conn = new SqlConnection(_configuration.Value))
            {
                konumlar = await conn.QueryAsync<Konumlar>("spKonumlar_GetAll", commandType: CommandType.StoredProcedure);
            }
            return konumlar;
        }
        //Search for data (very generic...you may need to adjust.
        
        public async Task<Konumlar> Konumlar_GetOne(int @ID)
        {
            Konumlar konumlar = new Konumlar();
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                konumlar = await conn.QueryFirstOrDefaultAsync<Konumlar>("spKonumlar_GetOne", parameters, commandType: CommandType.StoredProcedure);
            }
            return konumlar;
        }
        // Update one Konumlar row based on its KonumlarID (SQL Update)
        // This only works if you're already created the stored procedure.
        public async Task<bool> KonumlarUpdate(Konumlar konumlar)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", konumlar.ID, DbType.Int32);

                parameters.Add("Bina", konumlar.Bina, DbType.String);
                parameters.Add("Kat", konumlar.Kat, DbType.String);
                parameters.Add("Konum", konumlar.Konum, DbType.String);

                await conn.ExecuteAsync("spKonumlar_Update", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        // Physically delete one Konumlar row based on its KonumlarID (SQL Delete)
        // This only works if you're already created the stored procedure.
        public async Task<bool> KonumlarDelete(int ID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ID", ID, DbType.Int32);
            using (var conn = new SqlConnection(_configuration.Value))
            {
                await conn.ExecuteAsync("spKonumlar_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}