using ApiControllers.Data;
using ApiControllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControllers.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbDataAccess _dataAccess;

        public CategoryRepository(IDbDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            return await _dataAccess.GetDataAsync<CategoryModel, dynamic>(
                "dbo.spCategories_GetAll",
                new { }
                );
        }

        public async Task<CategoryModel?> GetCategoriesByIdAsync(int id)
        {
            var product = await _dataAccess.GetDataAsync<CategoryModel, dynamic>(
                "dbo.spCategories_GetById",
                new { CategoryID = id }
                );

            return product.FirstOrDefault();
        }

        public async Task AddCategoriesAsync(CategoryModel categoryModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spCategories_Insert",
                new { categoryModel.CategoryName }
                );
        }

        public async Task EditCategoriesAsync(CategoryModel categoryModel)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spCategories_Update",
                categoryModel
                );
        }

        public async Task DeleteCategoriesAsync(int id)
        {
            await _dataAccess.SaveDataAsync(
                "dbo.spCategories_Delete",
                new { CategoryID = id }
                );
        }
    }
}
