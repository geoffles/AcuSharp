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
            dateutc = DateTime.Parse(measurement.dateutc);
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
            var sb = new StringBuilder();

            sb.Append("?&dateutc="); sb.Append(dateutc.ToString("yyyy-MM-ddThh:mm:ss"));
            sb.Append("&id="); sb.Append(id);
            sb.Append("&mt="); sb.Append(mt);
            sb.Append("&sensor="); sb.Append(sensor);
            sb.Append("&sensorbattery="); sb.Append(sensorbattery);
            sb.Append("&rssi="); sb.Append(rssi);
            sb.Append("&hubbattery="); sb.Append(hubbattery);
            sb.Append("&baromin="); sb.Append(baromin.ToString(CultureInfo.InvariantCulture));
            sb.Append("&humidity="); sb.Append(humidity.ToString(CultureInfo.InvariantCulture));
            sb.Append("&tempf="); sb.Append(tempf.ToString(CultureInfo.InvariantCulture));
            sb.Append("&windspeedmph="); sb.Append(windspeedmph.ToString(CultureInfo.InvariantCulture));
            sb.Append("&winddir="); sb.Append(winddir.ToString(CultureInfo.InvariantCulture));
            sb.Append("&windgustmph="); sb.Append(windgustmph.ToString(CultureInfo.InvariantCulture));
            sb.Append("&windgustdir="); sb.Append(windgustdir.ToString(CultureInfo.InvariantCulture));
            sb.Append("&windspeedavgmph="); sb.Append(windspeedavgmph.ToString(CultureInfo.InvariantCulture));
            sb.Append("&heatindex="); sb.Append(heatindex.ToString(CultureInfo.InvariantCulture));
            sb.Append("&feelslike="); sb.Append(feelslike.ToString(CultureInfo.InvariantCulture));
            sb.Append("&windchill="); sb.Append(windchill.ToString(CultureInfo.InvariantCulture));
            sb.Append("&dewptf="); sb.Append(dewptf.ToString(CultureInfo.InvariantCulture));
            sb.Append("&dailyrainin="); sb.Append(dailyrainin.ToString("0.00", CultureInfo.InvariantCulture));
            sb.Append("&rainin="); sb.Append(rainin.ToString("0.00", CultureInfo.InvariantCulture));

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
