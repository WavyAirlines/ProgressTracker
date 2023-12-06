﻿using Microsoft.AspNetCore.Mvc;
using ProgressTracker.Models;
using System.Diagnostics;

namespace ProgressTracker.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}