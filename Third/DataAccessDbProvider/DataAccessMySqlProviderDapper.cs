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

        public async Task<Pet> AddPet(Pet pet)
        {
            var connectionString = "server=localhost;userid=alberto;password=vinazza;database=SpeedAPIsSchema;";
            var sql = "INSERT INTO ThirdApi (Id, Species, Name, Age) VALUES (@Id, @Species, @Name, @Age)";

            var newPet = new Pet();
            newPet.Id = pet.Id;
            newPet.Species = pet.Species;
            newPet.Name = pet.Name;
            newPet.Age = pet.Age;
            
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync<Pet>(sql, newPet);
            }
            
            // throw new System.NotImplementedException();
            return null;
        }

        public async Task<Pet> UpdatePet(int Id, Pet newPet)
        {
            var connectionString = "server=localhost;userid=alberto;password=vinazza;database=SpeedAPIsSchema;";
            var sql = $"UPDATE ThirdApi SET (Name, Species, Age) VALUES (@Name, @Species, @Age) WHERE Id = {Id}";

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync(sql);
            }

            return null;
        }

        public async Task DeletePet(int Id)
        {
            var connectionString = "server=localhost;userid=alberto;password=vinazza;database=SpeedAPIsSchema;";
            var sql = $"DELETE FROM ThirdApi WHERE ThirdApi.Id = {Id}";

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.QueryAsync<Pet>(sql);
            }

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