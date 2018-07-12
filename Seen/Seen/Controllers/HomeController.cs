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
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View(answers);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Sighting sighting)
        {
            await sightingRepository.CreateAsync(sighting);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Sightings")]
        public async Task<IActionResult> Sightings()
        {
            var list = await sightingRepository.SelectAllAsync();
            return View(list);
        }

        [HttpGet]
        [Route("DBlist")]
        public async Task<IActionResult> DBlist()
        {
            var list = await sightingRepository.SelectAllAsync();
            return Ok(list);
        }

        [HttpGet]
		[Route("ItsAMatch/{id}")]
        public async Task<IActionResult> ItsAMatch([FromRoute]long id)
		{
			var handle = await sightingRepository.SelectByIdAsync(id);
            return View(handle);
		}
    }
}
