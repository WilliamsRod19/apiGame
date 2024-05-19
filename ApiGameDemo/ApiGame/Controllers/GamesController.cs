using ApiControllers.Models;
using ApiControllers.Repositories.Games;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGame.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GamesController : ControllerBase
	{
		private readonly IGameRepository _gameRepository;

		public GamesController(IGameRepository gameRepository)
		{
			_gameRepository = gameRepository;
		}

		// GET: api/<GamesController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var games = await _gameRepository.GetGamesAsync();

			return Ok(games);
		}

		// GET api/<GamesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<GamesController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] GameModel gameModel)
		{
			await _gameRepository.AddGamesAsync(gameModel);

			return Created();
		}

		// PUT api/<GamesController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] GameModel gameModel)
		{
			var gamesEditable = await _gameRepository.GetGamesByIdAsync(id);

			if (gamesEditable == null)
			{
				return NotFound();
			}

			await _gameRepository.EditGamesAsync(gameModel);

			return Accepted();
		}

		// DELETE api/<GamesController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{

			await _gameRepository.DeleteGamesAsync(id);

			return Accepted();
		}
	}
}
