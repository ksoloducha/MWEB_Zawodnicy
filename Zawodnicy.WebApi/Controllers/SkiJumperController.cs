using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class SkiJumperController : Controller
    {
        private readonly ISkiJumperService _skiJumperService;

        public SkiJumperController(ISkiJumperService skiJumperService)
        {
            _skiJumperService = skiJumperService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            Console.WriteLine("BrowseAll");
            IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/skijumper/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkiJumper(int id)
        {
            Console.WriteLine($"get: {id}");
            SkiJumperDTO z = await _skiJumperService.GetById(id);
            return Json(z);
        }

        //https://localhost:5001/skijumper/filter?name=alan&country=ger
        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(string name, string country)
        {
            Console.WriteLine($"Get Filter: name: {name}, country: {country}");
            IEnumerable<SkiJumperDTO> z = await _skiJumperService.BrowseAllAndFilter(name, country);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateSkiJumper skiJumper)
        {
            SkiJumperDTO z = await _skiJumperService.AddSkiJumper(skiJumper);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateSkiJumper([FromBody] UpdateSkiJumper skiJumper, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _skiJumperService.EditSkiJumper(skiJumper, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSkiJumper(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _skiJumperService.DeleteSkiJumper(id);
            //return Json(z);
        }

    }
}