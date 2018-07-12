using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seen.Models;
using Seen.Repository;

namespace Seen.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;
        private Answers answers;

        public UserController(UserRepository userRepository, Answers answers)
        {
            this.answers = answers;
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View(answers);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Add(User user)
        {
            await userRepository.CreateAsync(user);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Route("DBlist2")]
        public async Task<IActionResult> DBlist()
        {
            var list = await userRepository.SelectAllAsync();
            return Ok(list);
        }
    }
}
