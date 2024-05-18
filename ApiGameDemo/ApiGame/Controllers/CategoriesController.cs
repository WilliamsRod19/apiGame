using ApiControllers.Models;
using ApiControllers.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return Ok(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryModel categoryModel)
        {
            await _categoryRepository.AddCategoriesAsync(categoryModel);

            return Created();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryModel categoryModel)
        {
            var productEditable = await _categoryRepository.GetCategoriesByIdAsync(id);

            if (productEditable == null)
            {
                return NotFound();
            }

            await _categoryRepository.EditCategoriesAsync(categoryModel);

            return Accepted();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            await _categoryRepository.DeleteCategoriesAsync(id);

            return Accepted();
        }
    }
}
