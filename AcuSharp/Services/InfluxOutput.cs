using AcuSharp.Models;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Services
{
    public class InfluxOutput : IWeatherOutput
    {
        public void Write(MetricMeasurement measurement)
        {
            string token = "";
            const string bucket = "";
            const string org = "";

            using (var client = InfluxDBClientFactory.Create("", token.ToCharArray()))
            {
                var point = PointData
                  .Measurement("weather")
                  .Tag("deviceId", measurement.id)
                  .Tag("deviceType", measurement.mt)
                  .Tag("sensorId", measurement.sensor)                 
                  .Field("sensorbattery", measurement.sensorbattery)
                  .Field("rssi", measurement.rssi)
                  .Field("hubbattery", measurement.hubbattery)
                  .Field("baromhpa", measurement.baromhpa)
                  .Field("humidity", measurement.humidity)
                  .Field("windspeedkph", measurement.windspeedkph)
                  .Field("winddir", measurement.winddir)
                  .Field("windgustkph", measurement.windgustkph)
                  .Field("windspeedavgkph", measurement.windspeedavgkph)
                  .Field("windgustdir", measurement.windgustdir)
                  .Field("heatindexc", measurement.heatindexc)
                  .Field("feelslikec", measurement.feelslikec)
                  .Field("windchillc", measurement.windchillc)
                  .Field("tempc", measurement.tempc)
                  .Field("dewptc", measurement.dewptc)
                  .Field("dailyrainmm", measurement.dailyrainmm)
                  .Field("rainmm", measurement.rainmm)
                  .Timestamp(DateTime.UtcNow, WritePrecision.S);

                using (var writeApi = client.GetWriteApi())
                {
                    writeApi.WritePoint(bucket, org, point);
                }
            }
        }
    }
}
