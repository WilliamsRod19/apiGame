using ApiControllers.Models;
using ApiControllers.Repositories.Developers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGame.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DevelopersController : ControllerBase
	{
		private readonly IDeveloperRepository _developerRepository;

		public DevelopersController(IDeveloperRepository developerRepository)
		{
			_developerRepository = developerRepository;
		}

		// GET: api/<DevelopersController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var developers = await _developerRepository.GetDevelopersAsync();

			return Ok(developers);
		}

		// GET api/<DevelopersController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<DevelopersController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] DeveloperModel developerModel)
		{
			await _developerRepository.AddDevelopersAsync(developerModel);

			return Created();
		}

		// PUT api/<DevelopersController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] DeveloperModel developerModel)
		{
			var developerEditable = await _developerRepository.GetDevelopersByIdAsync(id);

			if (developerEditable == null)
			{
				return NotFound();
			}

			await _developerRepository.EditDevelopersAsync(developerModel);

			return Accepted();
		}

		// DELETE api/<DevelopersController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{

			await _developerRepository.DeleteDevelopersAsync(id);

			return Accepted();
		}
	}
}
