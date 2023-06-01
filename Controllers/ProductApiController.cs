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
    [Route("api/products")]
    public class ProductPageController : Controller
    {
        private readonly IApi _api;

        public ProductPageController(IApi api)
        {
            _api = api;
        }

        // Get the page model for all products
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetProducts()
        {
            var productPages = await _api.Pages.GetAllAsync<ProductPage>();

            return Json(productPages);
        }
    }

}