using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Models;
using Piranha.Models;
using EG_Piranha.Models;
using System.IO;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class RecipeCategoryApiController : Controller
    {
        private readonly IApi _api;

        public RecipeCategoryApiController(IApi api)
        {
            _api = api;
        }

        [Route("{slug}")]
        public async Task<IActionResult> GetById(string slug)
        {
            var category = await _api.Pages.GetBySlugAsync<RecipeCategory>(slug);

            return Json(category);
        }
        // Get recipe category
        [Route("all")]
        public async Task<IActionResult> GetCategories()
        {
            var recipeCategories = await _api.Pages.GetAllAsync<RecipeCategory>();

            return Json(recipeCategories);
        }
    }
}