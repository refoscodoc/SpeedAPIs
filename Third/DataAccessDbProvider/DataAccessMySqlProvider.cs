using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Third.Models;
using Third.Services;

namespace Third.DataAccessDbProvider
{
    public class DataAccessMySqlProvider : IDataAccessProvider
    {
        private readonly DomainModelMySqlContext _context;
        private readonly ILogger _logger;

        public DataAccessMySqlProvider(DomainModelMySqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMySqlProvider");
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.ThirdApi.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }
        public async Task<Pet> UpdatePet(int id, Pet pet)
        {
            _context.ThirdApi.Update(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(int Id)
        {
            var entity = _context.ThirdApi.First(t => t.Id == Id);
            _context.ThirdApi.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Pet> GetPet(int Id)
        {
            // return await _context.DataEventRecords
            //     .Include(s => s.SourceInfo)
            //     .FirstAsync(t => t.Id == Id);
            return await _context.ThirdApi
                .FirstAsync(t => t.Id == Id);
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            // Using the shadow property EF.Property<DateTime>(dataEventRecord)
            // return await _context.DataEventRecords
            //     .Include(s => s.SourceInfo)
            //     .OrderByDescending(dataEventRecord => EF.Property<DateTime>(dataEventRecord, "UpdatedTimestamp"))
            //     .ToListAsync();
            
            // return await _context.ThirdApi
            //     .OrderByDescending(dataEventRecord => EF.Property<DateTime>(dataEventRecord, "UpdatedTimestamp"))
            //     .ToListAsync();
            
            return await _context.ThirdApi.OrderBy(x => x.Id)
                .ToListAsync();
        }
        
    }
}
