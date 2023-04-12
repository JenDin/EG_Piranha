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
    [Route("api/post")]
    public class PostApiController : Controller
    {
        private readonly IApi _api;

        public PostApiController(IApi api)
        {
            _api = api;
        }

        // Gets the post model for all posts in the specified archive
        [HttpGet]
        [Route("all/{archiveId}")]
        public async Task<IActionResult> GetAllPosts(Guid archiveId)
        {
            return Json(await _api.Posts.GetAllAsync<Post>(archiveId));
        }

        // Gets the post model for the post with the specified archive and slug
        [HttpGet]
        [Route("{archiveId}/{slug}")]
        public async Task<IActionResult> GetBySlugAndArchive(Guid archiveId, string slug)
        {
            return Json(await _api.Posts.GetBySlugAsync<PostBase>(archiveId, slug));
        }

        // Gets the post info model for the post with the specified id
        [HttpGet]
        [Route("info/{id:Guid}")]
        public async Task<IActionResult> GetInfoById(Guid id)
        {
            return Json(await _api.Posts.GetByIdAsync<PostInfo>(id));
        }

        // Gets the post info model for the post with the specified archive and slug
        [HttpGet]
        [Route("info/{archiveId}/{slug}")]
        public async Task<IActionResult> GetInfoBySlugAndSite(Guid archiveId, string slug)
        {
            return Json(await _api.Posts.GetBySlugAsync<PostInfo>(archiveId, slug));
        }
    }
}
