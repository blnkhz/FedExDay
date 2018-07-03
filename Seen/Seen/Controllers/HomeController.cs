using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seen.Models;
using Seen.Repository;

namespace Seen.Controllers
{
    public class HomeController : Controller
    {
        private SightingRepository sightingRepository;
        private Answers answers;

        public HomeController(SightingRepository sightingRepository, Answers answers)
        {
            this.sightingRepository = sightingRepository;
            this.answers = answers;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            //var list = await sightingRepository.SelectAllAsync();
            return View(answers);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Sighting sighting)
        {
            await sightingRepository.CreateAsync(sighting);
            return RedirectToAction("Index");
        }
    }
}
