using ApiControllers.Data;
using ApiControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Repositories.Developers
{
    public class DeveloperRepository : IDeveloperRepository
    {
		private readonly IDbDataAccess _dataAccess;

		public DeveloperRepository(IDbDataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<IEnumerable<DeveloperModel>> GetDevelopersAsync()
		{
			return await _dataAccess.GetDataAsync<DeveloperModel, dynamic>(
				"dbo.spDeveloper_GetAll",
				new { }
				);
		}

		public async Task<DeveloperModel?> GetDevelopersByIdAsync(int id)
		{
			var developer = await _dataAccess.GetDataAsync<DeveloperModel, dynamic>(
				"dbo.spDeveloper_GetById",
				new { DeveloperID = id }
				);

			return developer.FirstOrDefault();
		}

		public async Task AddDevelopersAsync(DeveloperModel developerModel)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spDeveloper_Insert",
				new { developerModel.DeveloperName, developerModel.DeveloperCountry }
				);
		}

		public async Task EditDevelopersAsync(DeveloperModel developerModel)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spDeveloper_Update",
				developerModel
				);
		}

		public async Task DeleteDevelopersAsync(int id)
		{
			await _dataAccess.SaveDataAsync(
				"dbo.spDeveloper_Delete",
				new { DeveloperID = id }
				);
		}
	}
}
