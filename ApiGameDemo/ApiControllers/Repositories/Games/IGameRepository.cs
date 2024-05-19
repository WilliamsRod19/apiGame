using ApiControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Repositories.Games
{
	public interface IGameRepository
	{
		Task AddGamesAsync(GameModel gameModel);
		Task DeleteGamesAsync(int id);
		Task EditGamesAsync(GameModel gameModel);
		Task<IEnumerable<GameModel>> GetGamesAsync();
		Task<GameModel?> GetGamesByIdAsync(int id);
	}
}
