using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Models
{
    public static class Converter
    {
        public static double ToHpa(this double @in)
        {
            return Math.Round(@in * 33.86389, 1, MidpointRounding.AwayFromZero);
        }

        public static double ToMm(this double @in)
        {
            return Math.Round(@in * 25.4d, 2, MidpointRounding.AwayFromZero);
        }

        public static double ToKph(this double mph)
        {
            return Math.Round(mph * 1.609344, 1, MidpointRounding.AwayFromZero);
        }

        public static double ToC(this double f)
        {
            return Math.Round((f - 32d) * (5 / 9d), 1, MidpointRounding.AwayFromZero);
        }
    }

    public class MetricMeasurement
    {
        public MetricMeasurement(RawMeasurement raw)
        {
            var measurement = new ImperialMeasurement(raw);

            dateutc = measurement.dateutc;
            id = measurement.id;
            mt = measurement.mt;
            sensor = measurement.sensor;
            sensorbattery = measurement.sensorbattery;
            rssi = measurement.rssi;
            hubbattery = measurement.hubbattery;
            baromhpa = measurement.baromin.ToHpa();
            humidity = measurement.humidity;
            tempc = measurement.tempf.ToC();
            windspeedkph = measurement.windspeedmph.ToKph();
            winddir = measurement.winddir;
            windgustkph = measurement.windgustmph.ToKph();
            windgustdir = measurement.windgustdir;
            windspeedavgkph = measurement.windspeedavgmph.ToKph();
            heatindexc = measurement.heatindex.ToC();
            feelslikec = measurement.feelslike.ToC();
            windchillc = measurement.windchill.ToC();
            dewptc = measurement.dewptf.ToC();
            dailyrainmm = measurement.dailyrainin.ToMm();
            rainmm = measurement.rainin.ToMm();

        }

        public DateTime dateutc { get; private set; }
        public string id { get; private set; }
        public string mt { get; private set; }
        public string sensor { get; private set; }
        public string sensorbattery { get; private set; }
        public string rssi { get; private set; }
        public string hubbattery { get; private set; }
        public int humidity { get; private set; }
        public int winddir { get; private set; }
        public double windspeedkph { get; private set; }
        public int windgustdir { get; private set; }
        public double windgustkph { get; private set; }
        public double windspeedavgkph { get; private set; }
        public double heatindexc { get; private set; }
        public double feelslikec { get; private set; }
        public double windchillc { get; private set; }
        public double tempc { get; private set; }
        public double dewptc { get; private set; }
        public double baromhpa { get; private set; }
        public double dailyrainmm { get; private set; }
        public double rainmm { get; private set; }
    }
}
