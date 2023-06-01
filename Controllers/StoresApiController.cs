using System;
using EG_Piranha.Models;
using Microsoft.AspNetCore.Mvc;
using Piranha;

namespace EG_Piranha.Controllers
{
    [ApiController]
    [Route("api/stores")]
    public class StoresApiController : Controller
    {
        private readonly IApi _api;

        public StoresApiController(IApi api)
        {
            _api = api;
        }

        // Get the page model for the stores
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetStores()
        {
            // Get all products pages
            var stores = await _api.Pages.GetAllAsync<StorePage>();

            return Json(stores);
        }
    }
}
