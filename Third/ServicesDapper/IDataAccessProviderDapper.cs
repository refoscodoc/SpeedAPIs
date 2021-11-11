using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Third.Models;

namespace Third.ServicesDapper
{
    public interface IDataAccessProviderDapper
    {
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPet(int petId);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> UpdatePet(int Id, Pet newPet);
        Task DeletePet(int Id);
    }
}