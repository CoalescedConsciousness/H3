using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BD_First.Data;
using BD_First.Models;

namespace BD_First.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherModelsController : ControllerBase
    {
        private readonly BD_FirstContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherModelsController(BD_FirstContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/WeatherModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherModel>>> GetWeatherModel()
        {
            WeatherService weatherService = new WeatherService(_context, _httpClientFactory);
            var res = await weatherService.GetWeatherAsync(false);
            return await _context.WeatherModel.ToListAsync();
        }

        // GET: api/WeatherModels/5
        [HttpGet("{loops}")]
        public async Task GetWeatherModel(int loops)
        {
            WeatherService weatherService = new WeatherService(_context, _httpClientFactory);

            int x = 0;
            while (x < loops)
            {
                var res = await weatherService.GetWeatherAsync(true);
                Thread.Sleep(TimeSpan.FromHours(1));
                Console.WriteLine(x);
                x++;
            }
        }

        // GET: api/WeatherModels/continuous
        [HttpGet]
        [Route("continuous")]
        public async Task GetWeatherModelContinuous()
        {
            int x = 1;
            WeatherService ws = new WeatherService(_context, _httpClientFactory);
            while (true)
            {
                Console.WriteLine($"Loop #{x}");
                var res = await ws.GetWeatherAsync(true);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                x++;
            }
        }
    }
}
