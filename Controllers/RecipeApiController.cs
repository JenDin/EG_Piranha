using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Identity;
using Piranha.Models;
using EG_Piranha.Models;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeApiController : Controller
    {
        private readonly IApi _api;

        public RecipeApiController(IApi api)
        {
            _api = api;
        }

        // Return sitemap
        private async Task<Piranha.Models.Sitemap> GetSiteMap(Guid? id = null)
        {
            var siteMap = await _api.Sites.GetSitemapAsync(id);

            return siteMap;
        }

        // Get recipes belonging to a specific category
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetRecipesFromCategory(string slug)
        {
            var siteMap = await GetSiteMap();

            var allSiteMapItems = new List<SitemapItem>();
            foreach (var item in siteMap)
            {
                var childItems = FetchAllChildSitemapItemsRecursively(item);
                allSiteMapItems.AddRange(childItems);
            }

            var match = allSiteMapItems
                .FirstOrDefault(x => x.Permalink.Contains(slug));

            var children = match?.Items;

            return Json(children);
        }

        [Route("{slug}")]
        public async Task<IActionResult> GetCategories(string slug)
        {
            var recipeCategories = await _api.Pages.GetAllAsync<RecipeCategory>();

            return Json(recipeCategories);
        }

        public List<SitemapItem> FetchAllChildSitemapItemsRecursively(SitemapItem sitemapItem)
        {
            var allSitemapItems = new List<SitemapItem>();

            // Loop through all child sitemap items
            foreach (var childItem in sitemapItem.Items)
            {
                // Add the child sitemap item to the list
                allSitemapItems.Add(childItem);

                // If the child item has children, call this function recursively
                if (childItem.Items != null && childItem.Items.Count > 0)
                {
                    var childSitemapItems = FetchAllChildSitemapItemsRecursively(childItem);
                    allSitemapItems.AddRange(childSitemapItems);
                }
            }

            return allSitemapItems;
        }



        // Get all recipe detail pages
        [HttpGet]
        [Route("recipe_details")]
        public async Task<IActionResult> GetRecipeDetails()
        {
            var recipeDetailsPages = await _api.Pages.GetAllAsync<RecipePage>();

            return Json(recipeDetailsPages);
        }
    }

}
