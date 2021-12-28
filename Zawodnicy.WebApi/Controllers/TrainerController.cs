using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            Console.WriteLine("BrowseAllTrainers");
            IEnumerable<TrainerDTO> z = await _trainerService.BrowseAll();
            return Json(z);
        }

        //https://localhost:5001/trainer/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainer(int id)
        {
            Console.WriteLine($"get: {id}");
            TrainerDTO z = await _trainerService.GetById(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainer trainer)
        {
            TrainerDTO z = await _trainerService.Add(trainer);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task UpdateTrainer([FromBody] UpdateTrainer trainer, int id)
        {
            Console.WriteLine($"Put: id {id}");
            await _trainerService.Edit(trainer, id);
            //return Json(z);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTrainer(int id)
        {
            Console.WriteLine($"Delete: id {id}");
            await _trainerService.Delete(id);
            //return Json(z);
        }
    }
}