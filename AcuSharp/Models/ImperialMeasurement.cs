using AcuSharp.Util;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcuSharp.Models
{
    public class ImperialMeasurement
    {   
        public ImperialMeasurement(RawMeasurement measurement)
        {
            dateutc = DateTime.Parse(measurement.dateutc + "Z").ToUniversalTime();
            id = measurement.id;
            mt = measurement.mt;
            sensor = measurement.sensor;
            sensorbattery = measurement.sensorbattery;
            rssi = measurement.rssi;
            hubbattery = measurement.hubbattery;
            baromin = double.Parse(measurement.baromin, CultureInfo.InvariantCulture);
            humidity = int.Parse(measurement.humidity, CultureInfo.InvariantCulture);
            tempf = double.Parse(measurement.tempf, CultureInfo.InvariantCulture);
            windspeedmph = double.Parse(measurement.windspeedmph, CultureInfo.InvariantCulture);
            winddir = int.Parse(measurement.winddir, CultureInfo.InvariantCulture);
            windgustmph = double.Parse(measurement.windgustmph, CultureInfo.InvariantCulture);
            windgustdir = int.Parse(measurement.windgustdir, CultureInfo.InvariantCulture);
            windspeedavgmph = double.Parse(measurement.windspeedavgmph, CultureInfo.InvariantCulture);
            heatindex = double.Parse(measurement.heatindex, CultureInfo.InvariantCulture);
            feelslike = double.Parse(measurement.feelslike, CultureInfo.InvariantCulture);
            windchill = double.Parse(measurement.windchill, CultureInfo.InvariantCulture);
            dewptf = double.Parse(measurement.dewptf, CultureInfo.InvariantCulture);
            dailyrainin = double.Parse(measurement.dailyrainin, CultureInfo.InvariantCulture);
            rainin = double.Parse(measurement.rainin, CultureInfo.InvariantCulture);
        }

        public string ToQueryString()
        {
            var sb = new StringBuilder()            
                .Append("?")
                .AppendUrlQuery("dateutc", dateutc.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss"))
                .AppendUrlQuery("id", id)
                .AppendUrlQuery("mt", mt)
                .AppendUrlQuery("sensor", sensor)
                .AppendUrlQuery("sensorbattery", sensorbattery)
                .AppendUrlQuery("rssi", rssi)
                .AppendUrlQuery("hubbattery", hubbattery)
                .AppendUrlQuery("baromin", baromin.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("humidity", humidity.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("tempf", tempf.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("windspeedmph", windspeedmph.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("winddir", winddir.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("windgustmph", windgustmph.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("windgustdir", windgustdir.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("windspeedavgmph", windspeedavgmph.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("heatindex", heatindex.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("feelslike", feelslike.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("windchill", windchill.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("dewptf", dewptf.ToString(CultureInfo.InvariantCulture))
                .AppendUrlQuery("dailyrainin", dailyrainin.ToString("0.00", CultureInfo.InvariantCulture))
                .AppendUrlQuery("rainin", rainin.ToString("0.00", CultureInfo.InvariantCulture));

            return sb.ToString();
        }

        

        public DateTime dateutc { get; private set; }
        public string id { get; private set; }
        public string mt { get; private set; }
        public string sensor { get; private set; }
        public string sensorbattery { get; private set; }
        public string rssi { get; private set; }
        public string hubbattery { get; private set; }
        public double baromin { get; private set; }
        public int humidity { get; private set; }
        public double tempf { get; private set; }
        public double windspeedmph { get; private set; }
        public int winddir { get; private set; }
        public double windgustmph { get; private set; }
        public int windgustdir { get; private set; }
        public double windspeedavgmph { get; private set; }
        public double heatindex { get; private set; }
        public double feelslike { get; private set; }
        public double windchill { get; private set; }
        public double dewptf { get; private set; }
        public double dailyrainin { get; private set; }
        public double rainin { get; private set; }
    }
}
