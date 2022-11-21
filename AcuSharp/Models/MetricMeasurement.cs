using AcuSharp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Models
{
    public class MetricMeasurement
    {
        private readonly ImperialMeasurement _imperialMeasurement;

        public MetricMeasurement(RawMeasurement raw)
        {
            _imperialMeasurement = new ImperialMeasurement(raw);

            dateutc = _imperialMeasurement.dateutc;
            id = _imperialMeasurement.id;
            mt = _imperialMeasurement.mt;
            sensor = _imperialMeasurement.sensor;
            sensorbattery = _imperialMeasurement.sensorbattery;
            rssi = _imperialMeasurement.rssi;
            hubbattery = _imperialMeasurement.hubbattery;
            baromhpa = _imperialMeasurement.baromin?.ToHpa();
            humidity = _imperialMeasurement.humidity;
            tempc = _imperialMeasurement.tempf?.ToC();
            windspeedkph = _imperialMeasurement.windspeedmph?.ToKph();
            winddir = _imperialMeasurement.winddir;
            windgustkph = _imperialMeasurement.windgustmph?.ToKph();
            windgustdir = _imperialMeasurement.windgustdir;
            windspeedavgkph = _imperialMeasurement.windspeedavgmph?.ToKph();
            heatindexc = _imperialMeasurement.heatindex?.ToC();
            feelslikec = _imperialMeasurement.feelslike?.ToC();
            windchillc = _imperialMeasurement.windchill?.ToC();
            dewptc = _imperialMeasurement.dewptf?.ToC();
            dailyrainmm = _imperialMeasurement.dailyrainin?.ToMm();
            rainmm = _imperialMeasurement.rainin?.ToMm();

        }

        public ImperialMeasurement ToImperialMeasurement() { return _imperialMeasurement; }

        public DateTime dateutc { get; private set; }
        public string id { get; private set; }
        public string mt { get; private set; }
        public string sensor { get; private set; }
        public string sensorbattery { get; private set; }
        public string rssi { get; private set; }
        public string hubbattery { get; private set; }
        public int? humidity { get; private set; }
        public int? winddir { get; private set; }
        public double? windspeedkph { get; private set; }
        public int? windgustdir { get; private set; }
        public double? windgustkph { get; private set; }
        public double? windspeedavgkph { get; private set; }
        public double? heatindexc { get; private set; }
        public double? feelslikec { get; private set; }
        public double? windchillc { get; private set; }
        public double? tempc { get; private set; }
        public double? dewptc { get; private set; }
        public double? baromhpa { get; private set; }
        public double? dailyrainmm { get; private set; }
        public double? rainmm { get; private set; }
    }
}
