using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.WebApp.Models;

namespace Zawodnicy.WebApp.Controllers
{
    public class SkiJumperController : Controller
    {
        public IConfiguration Configuration;

        public SkiJumperController(IConfiguration configuration)
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
            var tokenString = GenerateJSONWebToken();
            string _restpath = GetHostUrl().Content + controllerName();

            List<SkiJumperVM> skiJumpersList = new List<SkiJumperVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    skiJumpersList = JsonConvert.DeserializeObject<List<SkiJumperVM>>(apiResponse);
                }
            }

            return View(skiJumpersList);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperTajneHaslo112233"));
            var creadentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Name", "Katarzyna"),
                new Claim(JwtRegisteredClaimNames.Email, "01142469@pw.edu.pl"),
            };

            var token = new JwtSecurityToken(
                issuer: "http://www.katarzynasoloducha.pl",
                audience: "http://www.katarzynasoloducha.pl",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creadentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            SkiJumperVM s = new SkiJumperVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                }
            }

            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkiJumperVM s)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            SkiJumperVM sjResult = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{s.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch(Exception e)
            {
                return View(e);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            SkiJumperVM s = new SkiJumperVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                }
            }

            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SkiJumperVM s)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            SkiJumperVM sjResult = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{s.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
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
        public async Task<IActionResult> Create(SkiJumperVM s)
        {
            string _restpath = GetHostUrl().Content + controllerName();

            SkiJumperVM sjResult = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sjResult = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
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
