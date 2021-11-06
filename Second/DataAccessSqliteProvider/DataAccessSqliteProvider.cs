using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Second.Models;
using Second.Services;

namespace Second.DataAccessSqliteProvider
{
    public class DataAccessSqliteProvider : IDataAccessProvider
    {
        private readonly DomainModelSqliteContext _context;
        private readonly ILogger _logger;

        public DataAccessSqliteProvider(DomainModelSqliteContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessSqliteProvider");
        }
        public async Task<HorseModel> AddHorse(HorseModel horse)
        {
            _context.Horses.Add(horse);
            _context.HorsesViewmodels.Add(horse.HorsesViewmodels);
             
            await _context.SaveChangesAsync();
            return horse;
        }

        public Task<HorseModel> DeleteHorse(HorseModel horse)
        {
            throw new System.NotImplementedException();
        }

        public Task<HorseModel> EditHorse(HorseModel horse)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HorseModel> SearchHorse(HorseModel horse)
        {
            return await _context.Horses.FindAsync(horse);
        }

        public Task<IEnumerable<HorseModel>> GetHorses()
        {
            throw new System.NotImplementedException();
        }
    }
}