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
        public void Dispose()
        {
        }

        public int RetryDelayMs()
        {
            return 1000;
        }

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
                  .NonNullField("sensorbattery", measurement.sensorbattery)
                  .NonNullField("rssi", measurement.rssi)
                  .NonNullField("hubbattery", measurement.hubbattery)
                  .NonNullField("baromhpa", measurement.baromhpa)
                  .NonNullField("humidity", measurement.humidity)
                  .NonNullField("windspeedkph", measurement.windspeedkph)
                  .NonNullField("winddir", measurement.winddir)
                  .NonNullField("windgustkph", measurement.windgustkph)
                  .NonNullField("windspeedavgkph", measurement.windspeedavgkph)
                  .NonNullField("windgustdir", measurement.windgustdir)
                  .NonNullField("heatindexc", measurement.heatindexc)
                  .NonNullField("feelslikec", measurement.feelslikec)
                  .NonNullField("windchillc", measurement.windchillc)
                  .NonNullField("tempc", measurement.tempc)
                  .NonNullField("dewptc", measurement.dewptc)
                  .NonNullField("dailyrainmm", measurement.dailyrainmm)
                  .NonNullField("rainmm", measurement.rainmm)
                  .Timestamp(measurement.dateutc.ToUniversalTime(), WritePrecision.S);

                using (var writeApi = client.GetWriteApi())
                {
                    writeApi.WritePoint(bucket, org, point);
                }
            }
        }
    }

    static class Extensions
    {
        public static PointData NonNullField(this PointData pd, string field, string value)
        {
            if (value == null)
            {
                return pd;
            }

            return pd.Field(field, value);
        }

        public static PointData NonNullField(this PointData pd, string field, int? value)
        {
            if (!value.HasValue)
            {
                return pd;
            }

            return pd.Field(field, value.Value);
        }

        public static PointData NonNullField(this PointData pd, string field, double? value)
        {
            if (!value.HasValue)
            {
                return pd;
            }

            return pd.Field(field, value.Value);
        }
    }
}
