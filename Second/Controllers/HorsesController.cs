using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Second.Models;
using Second.Services;

namespace Second.Controllers
{
    [Route("api/[controller]")]
    public class HorsesController : Controller
    {
        private readonly BusinessProvider _businessProvider;

        public HorsesController(BusinessProvider businessProvider)
        {
            _businessProvider = businessProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HorseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllHorses()
        {
            return Ok(await _businessProvider.GetAllHorses());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HorseModel horse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (horse == null)
            {
                return BadRequest();
            }

            var result = await _businessProvider.AddHorse(horse);

            return Created("/api/Horse", result);
        }
    }
}