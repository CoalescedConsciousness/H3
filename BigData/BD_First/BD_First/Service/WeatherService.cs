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
using Microsoft.Spark;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            

            #endregion
            #region (4) Data Storage Layer
            // nom nom the data..
            foreach (var y in jObt["features"])
            {
                _ctx.Add(new IngestModel()
                {
                    Data = y.ToString(),
                    Date = DateTime.Parse((string)y["properties"]["to"], CultureInfo.InvariantCulture),
                    UsingTimer = timer,
                });
            }
            _ctx.SaveChanges();

        }
        #endregion
        #region (5) Data Query Layer
        /// <summary>
        /// Aggregates the number of entries based on the time of the measurement (i.e. Date property).
        /// </summary>
        /// <returns></returns>
        public Task PerDateCount()
        {

            var x = _ctx.IngestModel.GroupBy(w => w.Date)
                .Select(intermediate => new
                {
                    Date = intermediate.Key,
                    Frequency = intermediate.Sum(w => 1)
                })
                .OrderBy(x => x.Date).ToList();
            foreach (var y in x)
            {
                Console.WriteLine(y);
            }
            
            return null;
        }
        #endregion

        #region Extract & Transform
        public Task GetWindData()
        {
            var z = _ctx.IngestModel.Where(x => x.Data.Contains("wind"))
                .Select(i => new
                {
                    Date = i.Date,
                    Data = i.Data,
                })
                .GroupBy(r => r.Date)
                //.OrderBy(x => x.Date)
                .ToList();



            foreach (var a in z)
            {
                WeatherModel wm = new WeatherModel();
                wm.WindMax3 = 0;
                wm.WindMax10 = 0;
                wm.WindDir = 0;
                wm.WindMean = 0;
                foreach (var b in a)
                {


                    JObject obj = JObject.Parse(b.Data);
                    var coords = obj["geometry"]["coordinates"].ToList();
                    var value = (float)obj["properties"]["value"];
                    
                    wm.Timestamp = DateTime.Parse((string)obj["properties"]["to"], CultureInfo.InvariantCulture);
                    wm.Latitude = (float)coords[0];
                    wm.Longitude = (float)coords[1];

                    if (b.Data.Contains("max_wind_speed_3sec"))
                    {
                        wm.WindMax3 = value;
                    }
                    else if (b.Data.Contains("mean_wind_dir"))
                    {
                        wm.WindDir = value;
                    }
                    else if (b.Data.Contains("mean_wind_speed"))
                    {
                        wm.WindMean = value;
                    }
                    else if (b.Data.Contains("max_wind_speed_10min"))
                    {
                        wm.WindMax10 = value;
                    }

                }
                
                
                _ctx.WeatherModel.Add(wm);
                _ctx.SaveChanges();
                
            }
            return null;
        }
        #endregion

        // Not implemented yet:
        #region (6) Data Visualization Layer
        // This is carried out via Metabase, using SQLite database (potentially Spark) to get data to the container.
        #endregion
    }
}
