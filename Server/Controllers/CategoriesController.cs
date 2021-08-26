using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Server.Interfaces;
using KnowledgeBase.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBase.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Category>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }
    }
}