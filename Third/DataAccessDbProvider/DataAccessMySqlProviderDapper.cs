using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Third.Models;
using Third.ServicesDapper;
using Dapper;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Third.DataAccessDbProvider
{
    public class DataAccessMySqlProviderDapper : IDataAccessProviderDapper
    {
        private readonly DomainModelMySqlContext _context;
        private readonly ILogger _logger;

        public DataAccessMySqlProviderDapper(DomainModelMySqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMySqlProvider");
        }
        
        public Task<Pet> GetPet(int petId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> AddPet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pet> UpdatePet(int Id, Pet newPet)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePet(int Id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<Pet>> IDataAccessProviderDapper.GetAllPets()
        {
            var connectionString = "server=localhost;userid=alberto;password=vinazza;database=SpeedAPIsSchema;";
            var sql = "SELECT * FROM ThirdApi";
            
            using (var connection = new MySqlConnection(connectionString))
            {            
                var petsList = await connection.QueryAsync<Pet>(sql);
                return petsList.ToList();
            }
        }
    }
}