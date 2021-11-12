using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Third.Models;
using Third.Services;

namespace Third.ServicesDapper
{
    public class BusinessProviderDapper
    {
        private readonly IDataAccessProviderDapper _dataAccessProviderDapper;

        public BusinessProviderDapper(IDataAccessProviderDapper dataAccessProviderDapper)
        {
            _dataAccessProviderDapper = dataAccessProviderDapper;
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            var data = await _dataAccessProviderDapper.GetAllPets();

            var result = data.Select(pet => new Pet
            {
                Id = pet.Id,
                Species = pet.Species,
                Name = pet.Name,
                Age = pet.Age
            });


            return result;
        }

        public async Task<Pet> GetPet(int petId)
        {
            return await _dataAccessProviderDapper.GetPet(petId);
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            var newPet = new Pet
            {
                Id = pet.Id,
                Species = pet.Species,
                Name = pet.Name,
                Age = pet.Age
            };

            await _dataAccessProviderDapper.AddPet(newPet);

            return pet;
        }

        public async Task UpdatePet(int pet, Pet updatedPet)
        {
            // var oldPet = _dataAccessProvider.GetPet(pet.Id);

            var newPet = new Pet
            {
                Id = updatedPet.Id,
                Name = updatedPet.Name,
                Age = updatedPet.Age,
                Species = updatedPet.Species
            };

            await _dataAccessProviderDapper.UpdatePet(pet, newPet);
        }

        public async Task DeletePet(int petId)
        {
            await _dataAccessProviderDapper.DeletePet(petId);
        }
    }
}