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

        // Get recipes belonging to a specific category
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetRecipesFromCategory(string slug)
        {
            // 1. Get the sitemap
            var siteMap = await GetSiteMap();

            // 2. Get all children from the sitemap item however many levels deep
            var allSiteMapItems = new List<SitemapItem>();
            foreach (var item in siteMap)
            {
                var childItems = FetchAllChildSitemapItemsRecursively(item);
                // 3. Add each child on the same level
                allSiteMapItems.AddRange(childItems);
            }

            // 4. Get the slug for the first match
            var match = allSiteMapItems
                .FirstOrDefault(x => x.Permalink.Contains(slug));

            // 5. 
            var children = match?.Items;
            var pages = new List<RecipePage>();
            foreach(var child in children)
            {
                var page = await _api.Pages.GetByIdAsync<RecipePage>(child.Id);
                if(page != null)
                {
                    pages.Add(page);
                }
            }                

            return Json(pages);
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
    }
}
