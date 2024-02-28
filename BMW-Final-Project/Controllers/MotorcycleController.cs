﻿using BMW_Final_Project.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BMW_Final_Project.Controllers
{
    public class MotorcycleController : BaseController
    {
        private readonly IMotorcycleService _service;

        public MotorcycleController(IMotorcycleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _service.AllAsync();

            return View(model);
        }

        private string GetBuyerId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> LoadById (int id)
        {
            var model = await _service.LoadById(id);

            return View(model);
        }

    }
}
