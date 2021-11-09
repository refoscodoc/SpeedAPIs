using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Third.Models;

namespace Third.Services
{
    public class BusinessProvider
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BusinessProvider(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            var data = await _dataAccessProvider.GetAllPets();

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
            return await _dataAccessProvider.GetPet(petId);
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
            
            await _dataAccessProvider.AddPet(newPet);

            return pet;
        }
    }
}