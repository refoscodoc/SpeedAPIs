using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Second.Models;
using Second.ViewModels;

namespace Second.Services
{
    public class BusinessProvider
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BusinessProvider(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public async Task<IEnumerable<HorseModel>> GetAllHorses()
        {
            var data = await _dataAccessProvider.GetHorses();

            var result = data.Select(horse => new HorseModel
            {
                Id = horse.Id,
                Name = horse.Name,
                Age = horse.Age,
                Trainer = horse.Trainer,
                Owner = horse.Owner,
                StartingPrice = horse.StartingPrice
            });

            return result;
        }

        public async Task<HorseModel> GetHorse(HorseModel horse)
        {
            return await _dataAccessProvider.SearchHorse(horse);
        }

        public async Task<HorseModel> AddHorse(HorseModel horse)
        {
            var newHorse = new HorseModel
            {
                Id = Guid.NewGuid(),
                Name = horse.Name,
                Age = horse.Age,
                Trainer = horse.Trainer,
                Owner = horse.Owner,
                StartingPrice = horse.StartingPrice,
                HorsesViewmodelsId = Guid.NewGuid()
            };

            if (newHorse.HorsesViewmodels is null)
            {
                newHorse.HorsesViewmodels = new HorseViewModel()
                {
                    VmId = newHorse.HorsesViewmodelsId,
                    Name = horse.Name,
                    Price = horse.StartingPrice
                };
            }

            var der = await _dataAccessProvider.AddHorse(newHorse);

            return newHorse;
        }
    }
}