using ApiControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Repositories.Developers
{
	public interface IDeveloperRepository
	{
		Task AddDevelopersAsync(DeveloperModel developerModel);
		Task DeleteDevelopersAsync(int id);
		Task EditDevelopersAsync(DeveloperModel developerModel);
		Task<IEnumerable<DeveloperModel>> GetDevelopersAsync();
		Task<DeveloperModel?> GetDevelopersByIdAsync(int id);
	}
}
