using AcuSharp.Models;
using AcuSharp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AcuSharp.Tests
{
    public class WhenUploadingToAcurite
    {
        private readonly MetricMeasurement MEASUREMENT = new MetricMeasurement(new RawMeasurement(new QueryCollection(new Dictionary<string, StringValues>
        {
            ["dateutc"] = "2021-09-29T18:32:01",
            ["id"] = "ABC123ABC123",
            ["mt"] = "5N1",
            ["sensor"] = "12341234",
            ["sensorbattery"] = "normal",
            ["rssi"] = "1",
            ["hubbattery"] = "normal",
            ["baromin"] = "30.21",
            ["humidity"] = "33",
            ["tempf"] = "82.8",
            ["windspeedmph"] = "7",
            ["winddir"] = "270",
            ["windgustmph"] = "7",
            ["windgustdir"] = "270",
            ["windspeedavgmph"] = "5",
            ["heatindex"] = "81.3",
            ["feelslike"] = "80.6",
            ["windchill"] = "82.8",
            ["dewptf"] = "50.7",
            ["dailyrainin"] = "1.8",
            ["rainin"] = "0.1",
        })));

        private class TestMessageHandler : HttpMessageHandler
        {
            private Func<HttpRequestMessage, HttpResponseMessage> _onMessage;
            

            public TestMessageHandler OnMessage(Func<HttpRequestMessage, HttpResponseMessage> action)
            {
                _onMessage = action;
                return this;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_onMessage(request));
            }
        }

        [Fact]
        public void ThenMessagesMustSend()
        {
            string resultUri = Configuration.AcuriteServiceUrl + "?&dateutc=2021-09-29T18%3a32%3a01&id=ABC123ABC123&mt=5N1&sensor=12341234&sensorbattery=normal&rssi=1&hubbattery=normal&baromin=30.21&humidity=33&tempf=82.8&windspeedmph=7&winddir=270&windgustmph=7&windgustdir=270&windspeedavgmph=5&heatindex=81.3&feelslike=80.6&windchill=82.8&dewptf=50.7&dailyrainin=1.80&rainin=0.10";

            HttpRequestMessage m = null;
            var handler = new TestMessageHandler().OnMessage(a => { m = a; return new HttpResponseMessage(System.Net.HttpStatusCode.OK); });

            var invoker = new HttpMessageInvoker(handler);

            using (var acuriteOutput = new AcuriteOutput(invoker))
            {
                acuriteOutput.Write(MEASUREMENT);
            }

            var result = m.RequestUri;

            Assert.Equal(resultUri, m.RequestUri.ToString());
        }

        [Fact]
        public void ThenFailedMessagesMustThrow()
        {
            string resultUri = Configuration.AcuriteServiceUrl + "?&dateutc=2021-09-29T18%3a32%3a01&id=ABC123ABC123&mt=5N1&sensor=12341234&sensorbattery=normal&rssi=1&hubbattery=normal&baromin=30.21&humidity=33&tempf=82.8&windspeedmph=7&winddir=270&windgustmph=7&windgustdir=270&windspeedavgmph=5&heatindex=81.3&feelslike=80.6&windchill=82.8&dewptf=50.7&dailyrainin=1.80&rainin=0.10";

            HttpRequestMessage m = null;
            var handler = new TestMessageHandler().OnMessage(a => { m = a; return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest); });

            var invoker = new HttpMessageInvoker(handler);

            using (var acuriteOutput = new AcuriteOutput(invoker))
            {
                Assert.ThrowsAny<Exception>(() => acuriteOutput.Write(MEASUREMENT));
            }
        }
    }
}
