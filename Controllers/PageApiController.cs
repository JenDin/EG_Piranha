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

        // Gets the page model for a page with a specific id
        [HttpGet]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return Json(await _api.Pages.GetByIdAsync<PageBase>(id));
        }

        // Gets the page model for the page with the specified slug in the default site
        [HttpGet]
        [Route("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageBase>(slug));
        }

        // Gets the page info model for the page with the specified slug
        [HttpGet]
        [Route("info/{slug}")]
        public async Task<IActionResult> GetInfoBySlug(string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageInfo>(slug));
        }
    }

}