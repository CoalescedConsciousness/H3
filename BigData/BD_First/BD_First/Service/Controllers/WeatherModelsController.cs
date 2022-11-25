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
        private readonly IConfiguration _configuration;

        public WeatherModelsController(BD_FirstContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration; 
        }

        /// <summary>
        /// Returns a single snapshot dataset
        /// </summary>
        /// <returns></returns>
        // GET: api/WeatherModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherModel>>> GetWeatherModel()
        {
            WeatherService weatherService = new WeatherService(_context, _httpClientFactory);
            var res = await weatherService.GetWeatherAsync(false);
            return await _context.WeatherModel.ToListAsync();
        }

        /// <summary>
        /// Returns a number of datasets equal to the parameter (integer) given, spaced 1 hour apart.
        /// </summary>
        /// <param name="loops"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a continuous stream of datasets, for as long as the application runs.
        /// </summary>
        /// <returns></returns>
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
                Thread.Sleep(TimeSpan.FromHours(1));
                x++;
            }
        }

        // GET: api/WeatherModels/map
        [HttpGet]
        [Route("map")]
        public async Task GetDataByDate()
        {
            WeatherService ws = new WeatherService(_context, _httpClientFactory);
            //ws.PerDateCount();
            ws.GetWindData();
        }
    }
}
