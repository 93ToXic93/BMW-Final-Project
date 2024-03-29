﻿using BMW_Final_Project.Engine.Models.Motorcycle;
using Microsoft.AspNetCore.Mvc;

namespace BMW_Final_Project.Components
{
    public class AddColorModal : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(AddColorModel viewModel)
        {

            return await Task.FromResult<IViewComponentResult>(View(viewModel));
        }
    }
}
