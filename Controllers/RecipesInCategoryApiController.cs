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
    [Route("api/recipes_category")]
    public class RecipesInCategoryApiController : Controller
    {
        private readonly IApi _api;

        public RecipesInCategoryApiController(IApi api)
        {
            _api = api;
        }

        // Return sitemap
        private async Task<Piranha.Models.Sitemap> GetSiteMap(Guid? id = null)
        {
            var siteMap = await _api.Sites.GetSitemapAsync(id);

            return siteMap;
        }


        // Method that calls itself repeatedly to get all SitemapItems
        public List<SitemapItem> GetAllChildSitemapItemsRecursively(SitemapItem sitemapItem)
        {
            var allSitemapItems = new List<SitemapItem>();

            foreach (var childItem in sitemapItem.Items)
            {
                // Add the child sitemap item to the list
                allSitemapItems.Add(childItem);

                // If the child item has children, call this function recursively
                if (childItem.Items != null && childItem.Items.Count > 0)
                {
                    var childSitemapItems = GetAllChildSitemapItemsRecursively(childItem);
                    allSitemapItems.AddRange(childSitemapItems);
                }
            }
            return allSitemapItems;
        }

        // Get all recipes belonging to a specific category
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetRecipesFromCategory(string slug)
        {
            // Get the sitemap
            var siteMap = await GetSiteMap();

            // Get all children from the sitemap item however many levels deep
            var allSiteMapItems = new List<SitemapItem>();

            foreach (var item in siteMap)
            {
                var childItems = GetAllChildSitemapItemsRecursively(item);
                // Add each child on the same level
                allSiteMapItems.AddRange(childItems);
            }

            // Get the sitemapitem that matches the slug
            var match = allSiteMapItems
                .FirstOrDefault(x => x.Permalink.Contains(slug));

            var children = match?.Items;

            var pages = new List<RecipeDetailsPage>();

            foreach(var child in children)
            {
                var page = await _api.Pages.GetByIdAsync<RecipeDetailsPage>(child.Id);
                if(page != null)
                {
                    pages.Add(page);
                }
            }                

            return Json(pages);
        }
    }
}
