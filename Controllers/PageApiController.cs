using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.Models;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/page")]
    public class PageApiController : Controller
    {
        private readonly IApi _api;

        public PageApiController(IApi api, IAuthorizationService auth)
        {
            _api = api;
        }

        // Gets the page model for the page with the specified id
        [HttpGet]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return Json(await _api.Pages.GetByIdAsync<PageBase>(id));
        }

        // Gets the page model for the page with the specified slug in the default site
        [HttpGet]
        [Route("{slug}")]
        public virtual async Task<IActionResult> GetBySlug(string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageBase>(slug));
        }

        // Gets the page model for the page with the specified site and slug
        [HttpGet]
        [Route("{siteId}/{slug}")]
        public virtual async Task<IActionResult> GetBySlugAndSite(Guid siteId, string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageBase>(slug, siteId));
        }

        // Gets the page info model for the page with the specified id
        [HttpGet]
        [Route("info/{id:Guid}")]
        public virtual async Task<IActionResult> GetInfoById(Guid id)
        {
            return Json(await _api.Pages.GetByIdAsync<PageInfo>(id));
        }

        // Gets the page info model for the page with the specified slug
        [HttpGet]
        [Route("info/{slug}")]
        public virtual async Task<IActionResult> GetInfoBySlug(string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageInfo>(slug));
        }

        // Gets the page info model for the page with the specified slug and site
        [HttpGet]
        [Route("info/{siteId}/{slug}")]
        public virtual async Task<IActionResult> GetInfoBySlugAndSite(Guid siteId, string slug)
        {
            return Json(await _api.Pages.GetBySlugAsync<PageInfo>(slug, siteId));
        }
    }

}