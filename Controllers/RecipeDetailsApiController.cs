using System;
using EG_Piranha.Models;
using Microsoft.AspNetCore.Mvc;
using Piranha;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/details")]
    public class RecipeDetailsApiController : Controller
    {
        private readonly IApi _api;

        public RecipeDetailsApiController(IApi api)
        {
            _api = api;
        }

        // Get the page model for the recipe details of a specific slug
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetRecipeDetails(string slug)
        {
            var recipeDetailsPages = await _api.Pages.GetBySlugAsync<RecipeDetailsPage>(slug);

            return Json(recipeDetailsPages);
        }
    }
}