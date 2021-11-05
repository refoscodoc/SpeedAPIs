using System.Collections.Generic;
using System.Threading.Tasks;
using First.Models;

namespace First.Services
{
    public interface IDataAccessProvider
    {
        Task<GuitarModel> AddGuitar(GuitarModel guitar);

        Task<GuitarModel> DeleteGuitar(GuitarModel guitar);

        Task<GuitarModel> EditGuitar(GuitarModel guitar);

        Task<GuitarModel> SearchGuitar(GuitarModel guitar);

        Task<IEnumerable<GuitarModel>> GetGuitars();
    }
}