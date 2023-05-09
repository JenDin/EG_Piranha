using System;
using System.IO;
using EG_Piranha.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Identity;
using Piranha.Models;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/page")]
    public class PageApiController : Controller
    {
        private readonly IApi _api;

        public PageApiController(IApi api)
        {
            _api = api;
        }

        // Gets the page model for the page with the specified slug in the default site
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var pages = await _api.Pages.GetBySlugAsync<PageBase>(slug);

            return Json(pages);
        }
    }

}