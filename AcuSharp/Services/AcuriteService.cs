using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public class AcuriteService : IAcuriteService
    {
        public async Task<HttpResponseMessage> PostMeasurement(QueryString queryString)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Atlas/051");
                var body = string.Empty;

                var forwardRequestContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");


                var url = "https://atlasapi.myacurite.com/weatherstation/updateweatherstation" + queryString;

                var forwardResponse = await client.PostAsync(url, forwardRequestContent);

                return forwardResponse;
            }
        }
    }
}
