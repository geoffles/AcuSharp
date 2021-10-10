using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public class DummyAcuriteService : IAcuriteService
    {
        public async Task<HttpResponseMessage> PostMeasurement(QueryString queryString)
        {
            const string tzResponse = "{\"timezone\":\"+02:00\"}";
            var resp = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            resp.Content = new StringContent(tzResponse, Encoding.UTF8, "application/json");
            //resp.Headers.Add("Content-Length", tzResponse.Length.ToString());            
            resp.Headers.Date = DateTimeOffset.UtcNow;
            resp.Headers.Server.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Server", "Bobbo"));

            return resp;            
        }
    }
}
