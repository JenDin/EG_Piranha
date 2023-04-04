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

        public PostApiController(IApi api, IAuthorizationService auth)
        {
            _api = api;
        }

        // Gets the post model for the post with the specified id
        [HttpGet]
        [Route("{id:Guid}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            return Json(await _api.Posts.GetByIdAsync<PostBase>(id));
        }

        // Gets the post model for the post with the specified archive and slug
        [HttpGet]
        [Route("{archiveId}/{slug}")]
        public virtual async Task<IActionResult> GetBySlugAndArchive(Guid archiveId, string slug)
        {
            return Json(await _api.Posts.GetBySlugAsync<PostBase>(archiveId, slug));
        }

        [HttpGet]
        [Route("all/{archiveId}")]
        public virtual async Task<IActionResult> GetAll(Guid archiveId)
        {
            var posts = await _api.Posts.GetAllAsync<Post>(archiveId);
            return Json(posts);
        }

        // Gets the post info model for the post with the specified id
        [HttpGet]
        [Route("info/{id:Guid}")]
        public virtual async Task<IActionResult> GetInfoById(Guid id)
        {
            return Json(await _api.Posts.GetByIdAsync<PostInfo>(id));
        }

        // Gets the post info model for the post with the specified archive and slug
        [HttpGet]
        [Route("info/{archiveId}/{slug}")]
        public virtual async Task<IActionResult> GetInfoBySlugAndSite(Guid archiveId, string slug)
        {
            return Json(await _api.Posts.GetBySlugAsync<PostInfo>(archiveId, slug));
        }
    }
}
