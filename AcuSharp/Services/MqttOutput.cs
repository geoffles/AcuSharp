using AcuSharp.Models;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public sealed class MqttOutput : IWeatherOutput
    {
        private readonly MqttFactory _factory;
        private readonly IMqttClient _client;

        public MqttOutput()
        {
            _factory = new MqttFactory();

            var options = new MqttClientOptionsBuilder()
                .WithClientId("acusharp")
                .WithTcpServer("192.168.1.2", 1883)
                .WithCredentials("user", "p0svjaTl4ssfUji9XNiG")
                .Build();

            _client = _factory.CreateMqttClient();
            var a = _client.ConnectAsync(options);
            a.Wait();

            //var msg = new MqttApplicationMessageBuilder()
            //            .WithTopic($"homeassistant/sensor/weather_dailyrainmm/config")
            //            .WithRetainFlag()
            //            .WithPayload(value)
            //            .Build();

            //_client.PublishAsync(msg);
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public int RetryDelayMs()
        {
            return 1000;
        }

        private async Task Publish(string device, string metric, string value)
        {
            if (value == null) return;

            var msg = new MqttApplicationMessageBuilder()
                        .WithTopic($"weather/{device}/{metric}")
                        .WithPayload(value)
                        .Build();

            await _client.PublishAsync(msg);
        }

        private Task Publish(string device, string metric, double? value)
        {
            return Publish(device, metric, value?.ToString());
        }
        private Task Publish(string device, string metric, int? value)
        {
            return Publish(device, metric, value?.ToString());
        }

        public void Write(MetricMeasurement measurement)
        {
            Publish(measurement.id, "sensorbattery", measurement.sensorbattery);
            Publish(measurement.id, "rssi", measurement.rssi);
            Publish(measurement.id, "hubbattery", measurement.hubbattery);
            Publish(measurement.id, "baromhpa", measurement.baromhpa);
            Publish(measurement.id, "humidity", measurement.humidity);
            Publish(measurement.id, "windspeedkph", measurement.windspeedkph);
            Publish(measurement.id, "winddir", measurement.winddir);
            Publish(measurement.id, "windgustkph", measurement.windgustkph);
            Publish(measurement.id, "windspeedavgkph", measurement.windspeedavgkph);
            Publish(measurement.id, "windgustdir", measurement.windgustdir);
            Publish(measurement.id, "heatindexc", measurement.heatindexc);
            Publish(measurement.id, "feelslikec", measurement.feelslikec);
            Publish(measurement.id, "windchillc", measurement.windchillc);
            Publish(measurement.id, "tempc", measurement.tempc);
            Publish(measurement.id, "dewptc", measurement.dewptc);
            Publish(measurement.id, "dailyrainmm", measurement.dailyrainmm);
            Publish(measurement.id, "rainmm", measurement.rainmm);
        }
    }
}
