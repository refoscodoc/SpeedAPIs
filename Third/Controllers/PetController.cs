using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Third.Models;
using Third.Services;

namespace Third.Controllers
{
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private readonly BusinessProvider _businessProvider;

        public PetController(BusinessProvider businessProvider)
        {
            _businessProvider = businessProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pet>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetPets()
        {
            return Ok(await _businessProvider.GetAllPets());
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pet), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _businessProvider.GetPet(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPet([FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (pet == null)
            {
                return BadRequest();
            }

            var result = await _businessProvider.AddPet(pet);

            return Created("/api/Horse", result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> DeletePet(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            
            await _businessProvider.DeletePet(id);

            return Ok();
        }
    }
}