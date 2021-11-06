using System.Collections.Generic;
using System.Threading.Tasks;
using Second.Models;

namespace Second.Services
{
    public interface IDataAccessProvider
    {
        Task<HorseModel> AddHorse(HorseModel horse);

        Task<HorseModel> DeleteHorse(HorseModel horse);

        Task<HorseModel> EditHorse(HorseModel horse);

        Task<HorseModel> SearchHorse(HorseModel horse);

        Task<IEnumerable<HorseModel>> GetHorses();
    }
}