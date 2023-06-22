using Dapper;
using Servx.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Servx.Services
{
    public class ReservationService
    {

        private readonly string _connectionString;

        public ReservationService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public async Task<ResultModel> PostAsync(ResevationModel resevationModel)
        {
            try
            {
                using (var db = new SqlConnection(_connectionString))
                {
                    string sqlQuery = "INSERT INTO ReservationTable (Name, Tel, Reason, Description, DateTime) VALUES(@Name, @Tel, @Reason, @Description, @DateTime)";
                   await db.ExecuteAsync(sqlQuery, resevationModel);

                    return new ResultModel { Success = true };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ResultModel { Message = ex.Message };
            }
        }
    }
}
