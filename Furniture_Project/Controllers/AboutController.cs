﻿using Microsoft.AspNetCore.Mvc;

namespace Furniture_Project.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
