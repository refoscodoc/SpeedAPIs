using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Third.Models;

namespace Third.Services
{
    public interface IDataAccessProvider
    {
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPet(int petId);
        Task<Pet> AddPet(Pet pet);
    }
}