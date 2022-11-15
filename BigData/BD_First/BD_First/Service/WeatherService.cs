using BD_First.Models;
using BD_First.Service.Controllers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using BD_First.Data;
using System.Drawing.Text;
using System.Globalization;

namespace BD_First.Service
{
    public class WeatherService
    {
        private bool _firstRun = true;
        private string _runTime;
        private DateTime _runDateTime;
        private readonly IHttpClientFactory _clFact;
        private readonly BD_FirstContext _ctx;
        public WeatherService(BD_FirstContext ctx, IHttpClientFactory clFact)
        {
            _ctx = ctx;
            _clFact = clFact;
        }

        private async Task ParseWeatherData(JsonObject jObj)
        {
            JObject jObt = JObject.Parse(jObj.ToString());

            // Get "To" as DateTime for DB field to avoid future scrubbing when getting later data:
            _runDateTime = DateTime.ParseExact((string)jObt["features"][0]["properties"]["to"], "MM/dd/yyyy hh:mm:ss", CultureInfo.CurrentCulture);
            
            // Convert gotten data to UTC 3339 Compliant format (needed for API call in GetWeatherAsync else clause):
            _runTime = _runDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK");

            Console.WriteLine("TESTING");
            // nom nom the data..
            foreach (var y in jObt["features"])
            
            {
                Console.WriteLine("##############");
                Console.WriteLine(y.ToString());
                _ctx.Add(new IngestModel()
                {
                    Data = y.ToString(),
                    Date = _runDateTime,
                });
                //foreach (var x in y["properties"])
                //{ 
                //    Console.WriteLine(x);
                //    _ctx.Add(new IngestModel()
                //    {
                //        Data = (string)x,
                //        Date = _runDateTime,
                //    });
                //    await _ctx.SaveChangesAsync();
                //}
            }
            _ctx.SaveChanges();
            
        }

        public async Task<WeatherModel[]> GetWeatherAsync()
        { 

            HttpClient cl = _clFact.CreateClient("DMI");

            const string ApiKey = "ceeaa353-a263-4f66-b29d-9a14a3724a38";
            const string Municipality = "0340";
            const string Timespan = "hour";
            JsonObject res;
            //var test = await cl.GetFromJsonAsync
            //datetime=2022-11-15T06:00:00.00Z
            if (_firstRun)
            { 
                res = await cl.GetFromJsonAsync<JsonObject>($"/v2/climateData/collections/municipalityValue/items?timeResolution={Timespan}&municipalityId={Municipality}&api-key={ApiKey}");
                _firstRun = false;
            }
            else
            {
                res = await cl.GetFromJsonAsync<JsonObject>($"/v2/climateData/collections/municipalityValue/items?datetime={_runTime}/..&datetimeResolution={Timespan}&municipalityId={Municipality}&api-key={ApiKey}");
            }
            ParseWeatherData(res);


            //var result = res2["features"].Where(x => x["properties"]["parameterId"].Value<String>() == "bright_sunshine" ||
            //                                     x["properties"]["parameterId"].Value<String>() == "mean_radiation" ||
            //                                     x["properties"]["parameterId"].Value<String>() == "max_wind_speed_10min" ||
            //                                     x["properties"]["parameterId"].Value<String>() == "max_wind_speed_10min");

            //foreach (var x in result)
            //{
            //    Console.WriteLine(x);
            //    Console.WriteLine(x["properties"]["parameterId"]);
            //}
            ////foreach (var x in res.Where(x => x.Key == "features"))
            //{
            //    Console.WriteLine(x["properties"]);
            //}
            
            return null;
          
    
        }
    }
}
