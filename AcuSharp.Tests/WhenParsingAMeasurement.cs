using AcuSharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace AcuSharp.Tests
{
    public class WhenParsingAMeasurement
    {

        [Fact]
        public void ThenRawMeasurementsMustParse()
        {
            var queryCollection = new QueryCollection(new Dictionary<string, StringValues>
            {
                ["dateutc"] = "2021-09-29T08:32:01",
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
                ["dailyrainin"] = "0.00",
                ["rainin"] = "0.00",
            });

            var result = new RawMeasurement(queryCollection);

            Assert.Equal("2021-09-29T08:32:01", result.dateutc);
            Assert.Equal("ABC123ABC123", result.id);
            Assert.Equal("5N1", result.mt);
            Assert.Equal("12341234", result.sensor);
            Assert.Equal("normal", result.sensorbattery);
            Assert.Equal("1", result.rssi);
            Assert.Equal("normal", result.hubbattery);
            Assert.Equal("30.21", result.baromin);
            Assert.Equal("33", result.humidity);
            Assert.Equal("82.8", result.tempf);
            Assert.Equal("7", result.windspeedmph);
            Assert.Equal("270", result.winddir);
            Assert.Equal("7", result.windgustmph);
            Assert.Equal("270", result.windgustdir);
            Assert.Equal("5", result.windspeedavgmph);
            Assert.Equal("81.3", result.heatindex);
            Assert.Equal("80.6", result.feelslike);
            Assert.Equal("82.8", result.windchill);
            Assert.Equal("50.7", result.dewptf);
            Assert.Equal("0.00", result.dailyrainin);
            Assert.Equal("0.00", result.rainin);
        }

        [Fact]
        public void ThenImperialMeasurementsMustParse()
        {
            var raw = new RawMeasurement(new QueryCollection(new Dictionary<string, StringValues>
            {
                ["dateutc"] = "2021-09-29T08:32:01",
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
                ["dailyrainin"] = "0.00",
                ["rainin"] = "0.00",
            }));

            var result = new ImperialMeasurement(raw);

            Assert.Equal(new DateTime(2021, 09, 29, 8, 32, 1), result.dateutc);
            Assert.Equal("ABC123ABC123", result.id);
            Assert.Equal("5N1", result.mt);
            Assert.Equal("12341234", result.sensor);
            Assert.Equal("normal", result.sensorbattery);
            Assert.Equal("1", result.rssi);
            Assert.Equal("normal", result.hubbattery);
            Assert.Equal(30.21, result.baromin);
            Assert.Equal(33, result.humidity);
            Assert.Equal(82.8, result.tempf);
            Assert.Equal(7, result.windspeedmph);
            Assert.Equal(270, result.winddir);
            Assert.Equal(7, result.windgustmph);
            Assert.Equal(270, result.windgustdir);
            Assert.Equal(5, result.windspeedavgmph);
            Assert.Equal(81.3, result.heatindex);
            Assert.Equal(80.6, result.feelslike);
            Assert.Equal(82.8, result.windchill);
            Assert.Equal(50.7, result.dewptf);
            Assert.Equal(0.00, result.dailyrainin);
            Assert.Equal(0.00, result.rainin);
        }

        [Fact]
        public void ThenMetricMeasurementsMustParse()
        {
            var raw = new RawMeasurement(new QueryCollection(new Dictionary<string, StringValues>
            {
                ["dateutc"] = "2021-09-29T08:32:01",
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
            }));

            var result = new MetricMeasurement(raw);

            Assert.Equal(new DateTime(2021, 09, 29, 8, 32, 1, DateTimeKind.Utc), result.dateutc);
            Assert.Equal("ABC123ABC123", result.id);
            Assert.Equal("5N1", result.mt);
            Assert.Equal("12341234", result.sensor);
            Assert.Equal("normal", result.sensorbattery);
            Assert.Equal("1", result.rssi);
            Assert.Equal("normal", result.hubbattery);
            Assert.Equal(1023.0, result.baromhpa);
            Assert.Equal(33, result.humidity);
            Assert.Equal(28.2, result.tempc);
            Assert.Equal(11.3, result.windspeedkph);
            Assert.Equal(270, result.winddir);
            Assert.Equal(11.3, result.windgustkph);
            Assert.Equal(270, result.windgustdir);
            Assert.Equal(8.0, result.windspeedavgkph);
            Assert.Equal(27.4, result.heatindexc);
            Assert.Equal(27.0, result.feelslikec);
            Assert.Equal(28.2, result.windchillc);
            Assert.Equal(10.4, result.dewptc);
            Assert.Equal(45.72, result.dailyrainmm);
            Assert.Equal(2.54, result.rainmm);
        }

        [Fact]
        public void ThenImperialMeasurementsMustRevertToTheOriginalString()
        {
            const string TARGET_RESULT = "?&dateutc=2021-09-29T18%3a32%3a01&id=ABC123ABC123&mt=5N1&sensor=12341234&sensorbattery=normal&rssi=1&hubbattery=normal&baromin=30.21&humidity=33&tempf=82.8&windspeedmph=7&winddir=270&windgustmph=7&windgustdir=270&windspeedavgmph=5&heatindex=81.3&feelslike=80.6&windchill=82.8&dewptf=50.7&dailyrainin=1.80&rainin=0.10";

            var imperial = new ImperialMeasurement(new RawMeasurement(new QueryCollection(new Dictionary<string, StringValues>
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

            var result = imperial.ToQueryString();

            Assert.Equal(TARGET_RESULT, result);
        }
        
    }
}
