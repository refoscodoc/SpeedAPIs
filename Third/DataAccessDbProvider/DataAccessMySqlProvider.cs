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
        public async Task UpdateDataEventRecord(long dataEventRecordId, Pet pet)
        {
            _context.ThirdApi.Update(pet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDataEventRecord(int Id)
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
            
            return await _context.ThirdApi
                .ToListAsync();
        }
        //
        // public async Task<List<SourceInfo>> GetSourceInfos(bool withChildren)
        // {
        //     // Using the shadow property EF.Property<DateTime>(srcInfo)
        //     if (withChildren)
        //     {
        //         return await _context.SourceInfos.Include(s => s.DataEventRecords).OrderByDescending(srcInfo => EF.Property<DateTime>(srcInfo, "UpdatedTimestamp")).ToListAsync();
        //     }
        //
        //     return await _context.SourceInfos.OrderByDescending(srcInfo => EF.Property<DateTime>(srcInfo, "UpdatedTimestamp")).ToListAsync();
        // }
        //
        // public async Task<bool> DataEventRecordExists(long id)
        // {
        //     var filteredDataEventRecords = _context.DataEventRecords
        //         .Where(item => item.DataEventRecordId == id);
        //
        //     return await filteredDataEventRecords.AnyAsync();
        // }
        //
        // public async Task<SourceInfo> AddSourceInfo(SourceInfo sourceInfo)
        // {
        //     _context.SourceInfos.Add(sourceInfo);
        //     await _context.SaveChangesAsync();
        //     return sourceInfo;
        // }
        //
        // public async Task<bool> SourceInfoExists(long id)
        // {
        //     var filteredSourceInfoRecords = _context.SourceInfos
        //         .Where(item => item.SourceInfoId == id);
        //
        //     return await filteredSourceInfoRecords.AnyAsync();
        // }
    }
}
