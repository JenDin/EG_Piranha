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

        // Get the post model for all posts in the specified archive
        [HttpGet]
        [Route("all/{archiveId}")]
        public async Task<IActionResult> GetAllPosts(Guid archiveId)
        {
           var allPosts = await _api.Posts.GetAllAsync<Post>(archiveId);

            return Json(allPosts);
        }

        // Get the post model for the post with the specified archive and slug
        [HttpGet]
        [Route("{archiveId}/{slug}")]
        public async Task<IActionResult> GetBySlugAndArchive(Guid archiveId, string slug)
        {
            var postBySlug = await _api.Posts.GetBySlugAsync<PostBase>(archiveId, slug);

            return Json(postBySlug);
        }
    }
}