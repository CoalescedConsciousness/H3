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
            var res = await weatherService.GetWeatherAsync();
            Console.WriteLine(res);
            Console.WriteLine("WAHEY");
            return await _context.WeatherModel.ToListAsync();
        }

        // GET: api/WeatherModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherModel>> GetWeatherModel(int id)
        {
            var weatherModel = await _context.WeatherModel.FindAsync(id);

            if (weatherModel == null)
            {
                return NotFound();
            }

            return weatherModel;
        }

        // PUT: api/WeatherModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherModel(int id, WeatherModel weatherModel)
        {
            if (id != weatherModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherModel>> PostWeatherModel(WeatherModel weatherModel)
        {
            _context.WeatherModel.Add(weatherModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherModel", new { id = weatherModel.Id }, weatherModel);
        }

        // DELETE: api/WeatherModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherModel(int id)
        {
            var weatherModel = await _context.WeatherModel.FindAsync(id);
            if (weatherModel == null)
            {
                return NotFound();
            }

            _context.WeatherModel.Remove(weatherModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherModelExists(int id)
        {
            return _context.WeatherModel.Any(e => e.Id == id);
        }
    }
}
