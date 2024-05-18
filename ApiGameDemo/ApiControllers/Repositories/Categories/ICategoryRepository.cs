using ApiControllers.Models;

namespace ApiControllers.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task AddCategoriesAsync(CategoryModel categoryModel);
        Task DeleteCategoriesAsync(int id);
        Task EditCategoriesAsync(CategoryModel categoryModel);
        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel?> GetCategoriesByIdAsync(int id);
    }
}