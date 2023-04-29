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
    [Route("api/sitemap")]
    public class SiteMapController : Controller
	{
        private readonly IApi _api;

        public SiteMapController(IApi api)
        {
            _api = api;
        }

        // Get the sitemap of the site
        [HttpGet]
        [Route("{id:Guid?}")]
        public virtual async Task<IActionResult> GetById(Guid? id = null)
        {
            return Json(await _api.Sites.GetSitemapAsync(id));
        }
    }
}

