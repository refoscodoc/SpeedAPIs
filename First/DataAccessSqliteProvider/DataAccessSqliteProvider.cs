using System.Collections.Generic;
using System.Threading.Tasks;
using First.Models;
using First.Services;
using Microsoft.Extensions.Logging;

namespace First.DataAccessSqliteProvider
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
        public async Task<GuitarModel> AddGuitar(GuitarModel guitar)
        {
            _context.Guitars.Add(guitar);
            await _context.SaveChangesAsync();
            return guitar;
        }

        public Task<GuitarModel> DeleteGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuitarModel> EditGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuitarModel> SearchGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GuitarModel>> GetGuitars()
        {
            throw new System.NotImplementedException();
        }
    }
}