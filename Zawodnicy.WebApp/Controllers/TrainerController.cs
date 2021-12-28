using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    public class TrainerController : Controller
    {
        public IConfiguration Configuration;

        public TrainerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string controllerName()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                string _restpath = GetHostUrl().Content + controllerName();

                List<TrainerVM> trainersList = new List<TrainerVM>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        trainersList = JsonConvert.DeserializeObject<List<TrainerVM>>(apiResponse);
                    }
                }
                return View(trainersList);
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            TrainerVM t = new TrainerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                }
            }

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrainerVM t)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            TrainerVM tResult = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{t.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        tResult = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            TrainerVM t = new TrainerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                }
            }

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TrainerVM t)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            TrainerVM tResult = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{t.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        tResult = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainerVM t)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            TrainerVM tResult = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        tResult = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

