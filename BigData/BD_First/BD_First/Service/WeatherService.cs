using BD_First.Models;
using BD_First.Service.Controllers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using BD_First.Data;
using System.Drawing.Text;
using System.Globalization;
using Microsoft.Spark.Sql;


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
     
        #region (1) Data Ingestion Layer
        public async Task<WeatherModel[]> GetWeatherAsync(bool timer=false)
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
                Console.WriteLine($"/v2/climateData/collections/municipalityValue/items?datetime={_runTime}/..&municipalityId={Municipality}&api-key={ApiKey}");
                res = await cl.GetFromJsonAsync<JsonObject>($"/v2/climateData/collections/municipalityValue/items?datetime={_runTime}/..&municipalityId={Municipality}&api-key={ApiKey}");
            }
            #endregion
            #region (2) Data Collection Layer
            await ParseWeatherData(res, timer);
            
            return null;
        }
        #endregion
        #region (3) Data Processing Layer
        private async Task ParseWeatherData(JsonObject jObj, bool timer)
        {
            JObject jObt = JObject.Parse(jObj.ToString());

            // Get "To" as DateTime for DB field to avoid future scrubbing when getting later data:
            _runDateTime = DateTime.Parse((string)jObt["features"][0]["properties"]["to"], CultureInfo.InvariantCulture);

            // Convert gotten data to UTC 3339 Compliant format (needed for API call in GetWeatherAsync else clause):
            _runTime = _runDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss") + "%2B02:00";
            //SparkSession spark = SparkSession.Builder()
            //                    .AppName("weather")
            //                    .GetOrCreate();

            //DataFrame df = spark.Read().Json(jObj.ToString());

            #endregion
            #region (4) Data Storage Layer
            // nom nom the data..
            foreach (var y in jObt["features"])
            {
                _ctx.Add(new IngestModel()
                {
                    Data = y.ToString(),
                    Date = _runDateTime,
                    UsingTimer = timer,
                });
            }
            _ctx.SaveChanges();

        }
        #endregion


        // Not implemented:
        #region (5) Data Query Layer
        public Task PerDateCount()
        {

            var x = _ctx.IngestModel.GroupBy(w => w.Date)
                .Select(intermediate => new
                {
                    Date = intermediate.Key,
                    Frequency = intermediate.Sum(w => 1)
                })
                .OrderBy(x => x.Date).ToList();
            
            return null;
        }
        #endregion
        #region (6) Data Visualization Layer
        #endregion
    }
}
