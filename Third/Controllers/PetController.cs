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
        public async Task<IActionResult> Get(int petId)
        {
            return Ok(await _businessProvider.GetPet(petId));
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
    }
}