using ApiControllers.Data;
using ApiControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Repositories.Games
{
    public class GameRepository : IGameRepository
    {
		private readonly IDbDataAccess _dataAccess;

		public GameRepository(IDbDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<IEnumerable<GameModel>> GetGamesAsync()
		{
			return await _dataAccess.GetDataAsync<GameModel, dynamic>(
				"dbo.spGame_GetAll",
				new { }
				);
		}

		public async Task<GameModel?> GetGamesByIdAsync(int id)
		{
			var game = await _dataAccess.GetDataAsync<GameModel, dynamic>(
				"dbo.spGame_GetById",
				new { GameID = id }
				);

			return game.FirstOrDefault();
		}

		public async Task AddGamesAsync(GameModel gameModel)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spGame_Insert",
				new { gameModel.GameName, gameModel.GameDescription, gameModel.GameReleaseDate, gameModel.GamePrice, gameModel.GameDeveloperID, gameModel.GameCategoryID }
				);
		}

		public async Task EditGamesAsync(GameModel gameModel)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spGame_Update",
				gameModel
				);
		}

		public async Task DeleteGamesAsync(int id)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spGame_Delete",
				new { GameID = id }
				);
		}
	}
}
