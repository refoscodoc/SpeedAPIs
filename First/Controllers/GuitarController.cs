using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using First.Services;
using First.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First.Controllers
{
    [Route("api/[controller]")]
    public class GuitarController : Controller
    {
        private readonly BusinessProvider _businessProvider;

        public GuitarController(BusinessProvider businessProvider)
        {
            _businessProvider = businessProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GuitarViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _businessProvider.GetGuitars());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GuitarViewModel guitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (guitar == null)
            {
                return BadRequest();
            }

            var result = await _businessProvider.AddGuitar(guitar);

            return Created("/api/Guitar", result);
        }
    }
}