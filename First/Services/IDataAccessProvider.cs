using System.Collections.Generic;
using System.Threading.Tasks;
using First.Models;

namespace First.Services
{
    public interface IDataAccessProvider
    {
        Task<GuitarModel> AddGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        Task<GuitarModel> DeleteGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        Task<GuitarModel> EditGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        Task<GuitarModel> SearchGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<GuitarModel>> GetGuitars()
        {
            throw new System.NotImplementedException();
        }
    }
}