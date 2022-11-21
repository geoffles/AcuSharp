using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AcuSharp.Models;
using AcuSharp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcuSharp.Controllers
{
    [Route("weatherstation")]
    public class WeatherStationController : Controller
    {

        

        //add ssl route: https://0.0.0.0:5001;
        [Route("ping")]
        public async Task<string> Ping()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost]
        [Route("updateweatherstation")]
        public async Task<ActionResult> UpdateWeatherStation(IFormCollection collection)
        {

            var rawMeasurement = new RawMeasurement(Request.Query);
            Console.WriteLine(Request.QueryString);

            IAcuriteService acurite = new AcuriteService();

            var forwardResponse = await acurite.PostMeasurement(Request.QueryString);
            Console.WriteLine($"{DateTime.Now}: {forwardResponse.StatusCode}");

            var headerDate = forwardResponse.Headers.GetValues("Date").FirstOrDefault();
            var headerServer = forwardResponse.Headers.GetValues("Server").FirstOrDefault();

            var response = forwardResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(response);
            
            Response.Headers.Add("Date", headerDate);
            Response.Headers.Add("Server", headerServer);

            Response.Headers.Add("Content-Length", response.Length.ToString());

            var metricMeasurement = new MetricMeasurement(rawMeasurement);
            var influxOutput = new InfluxOutput();
            using(var mqtt = new MqttOutput())
            {
                mqtt.Write(metricMeasurement);
            }

            influxOutput.Write(metricMeasurement);

            var result = new ContentResult()
            {
                Content = response,
                ContentType = "application/json",
                StatusCode = 200
            };

            return result;
            



            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Add("User-Agent", "Atlas/051");
            //    var body = new StreamReader(Request.BodyReader.AsStream()).ReadToEnd();

            //    var forwardRequestContent = new StringContent(body, Encoding.UTF8, Request.ContentType);


            //    var url = "https://atlasapi.myacurite.com/weatherstation/updateweatherstation" + Request.QueryString;
                

                

            //    Console.WriteLine(Request.QueryString);

            //    var forwardResponse = await client.PostAsync(url, forwardRequestContent);
            //    Console.WriteLine($"{DateTime.Now}: {forwardResponse.StatusCode}");

            //    //if (!forwardResponse.IsSuccessStatusCode)
            //    //{
            //    //    //Response.Headers.Add("Date", DateTime.Now.ToString());
            //    //    //Response.Headers.Add("Server", "unicorn");

            //    //    //var response = "{\"timezone\":\"+02:00\"}";
            //    //    //var bytes = Encoding.UTF8.GetBytes(response);

            //    //    Response.Headers.Add("Content-Length", response.Length.ToString());

            //    //    var result = new ContentResult()
            //    //    {
            //    //        Content = response,
            //    //        ContentType = "application/json",
            //    //        StatusCode = 200
            //    //    };

            //    //    return result;
            //    //}

            //    var headerDate = forwardResponse.Headers.GetValues("Date").FirstOrDefault();
            //    var headerServer = forwardResponse.Headers.GetValues("Server").FirstOrDefault();

            //    var response = forwardResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //    Console.WriteLine(response);
            //    //Response.ContentType = "application/json";
            //    Response.Headers.Add("Date", headerDate);
            //    Response.Headers.Add("Server", headerServer);


            //    //Response.Headers.Add("Date", DateTime.Now.ToString());
            //    //Response.Headers.Add("Server", "unicorn");

            //    //var response = "{\"timezone\":\"+02:00\"}";
            //    //var bytes = Encoding.UTF8.GetBytes(response);

            //    Response.Headers.Add("Content-Length", response.Length.ToString());

            //    var result = new ContentResult()
            //    {
            //        Content = response,
            //        ContentType = "application/json",
            //        StatusCode = 200
            //    };

            //    return result;
            //}


            
        }
    }
}
