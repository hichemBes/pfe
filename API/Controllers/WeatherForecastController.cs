using Domain.Foriegn_Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        HttpClient _httpClient = new HttpClient();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("&&")]

 
        public UserDto GetuserById(Guid iduser)
            {
                HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44377/Identity?userId=" + iduser).Result;
                response.EnsureSuccessStatusCode();
                System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
                var responseBody = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<UserDto>(responseBody);
            }
        [HttpGet("fillialetest")]
        public FillialeDto getsubsidiarybyid(Guid fillialeid)
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:44349/" + fillialeid).Result;
            response.EnsureSuccessStatusCode();
            System.Console.WriteLine("response.Headers: " + response.Headers.ToString());
            var responsebody = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<FillialeDto>(responsebody);

        }
    }
    }
