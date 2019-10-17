using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeepMusic.Models;
using DeepMusic.Services;
using Microsoft.AspNetCore.Hosting;


namespace DeepMusic.Controllers
{
    public class HomeController : Controller
    {
        private ITextFileOperations _textFileOperations;
        public HomeController(ITextFileOperations textFileOperations)
        {
            _textFileOperations = textFileOperations;
        }
        public IActionResult Index()
        {
            // here you would put a switch statement, that could change what info or settings the user is placed with 
            ViewBag.Welcome = "Welcome to DeepMusic 42 is not the answer";


            ViewData["Conditions"] = _textFileOperations.Loadinfo();

            return View();
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
