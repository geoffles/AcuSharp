using AcuSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public sealed class AcuriteOutput : IWeatherOutput
    {
        private HttpMessageInvoker _client;

        public AcuriteOutput(HttpMessageInvoker client)
        {
            _client = client;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public int RetryDelayMs()
        {
            return 60000;
        }

        public void Write(MetricMeasurement measurement)
        {
            var queryString = measurement.ToImperialMeasurement().ToQueryString();
            SendToAcurite(queryString).Wait();
        }

        private async Task<HttpResponseMessage> SendToAcurite(string queryString)
        {
            var body = string.Empty;

            var forwardRequestContent = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

            var url = Configuration.AcuriteServiceUrl + queryString;

            var msg = new HttpRequestMessage(HttpMethod.Post, url);
            msg.Content = forwardRequestContent;
            msg.Headers.Add("User-Agent", "Atlas/051");

            var forwardResponse = await _client.SendAsync(msg, CancellationToken.None);

            Console.WriteLine(forwardResponse.StatusCode);

            return forwardResponse;
        }
    }
}
