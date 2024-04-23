using InventoryManagement.Core.Models;
using InventoryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoyController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoyController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var catList = await _categoryService.GetAllCategories();
            if(catList == null)
            {
                return NotFound();
            }
            return Ok(catList);
        }
        [HttpGet("{CategoryId}")]
        public async Task<IActionResult> GetCatById(int CategoryId)
        {
            var category = await _categoryService.GetCategoryById(CategoryId);
            if(category != null)
            {
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCat(Category cat)
        {
            var isCatCreated = await _categoryService.CreateCategory(cat);
            if(isCatCreated)
            {
                return Ok(isCatCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCat(Category cat)
        {
            if(cat != null)
            {
                var isCatCreated = await _categoryService.UpdateCategory(cat);
                if( isCatCreated)
                {
                    return Ok(isCatCreated);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var isCatCreated = await _categoryService.DeleteCategory(id);
            if (isCatCreated)
            {
                return Ok(isCatCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
