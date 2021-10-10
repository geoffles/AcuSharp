using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Models
{
    public class RawMeasurement
    {
        public RawMeasurement(IQueryCollection  QueryString )
        {
            dateutc = QueryString["dateutc"];
            id = QueryString["id"];
            mt = QueryString["mt"];
            sensor = QueryString["sensor"];
            sensorbattery = QueryString["sensorbattery"];
            rssi = QueryString["rssi"];
            hubbattery = QueryString["hubbattery"];
            baromin = QueryString["baromin"];
            humidity = QueryString["humidity"];
            tempf = QueryString["tempf"];
            windspeedmph = QueryString["windspeedmph"];
            winddir = QueryString["winddir"];
            windgustmph = QueryString["windgustmph"];
            windgustdir = QueryString["windgustdir"];
            windspeedavgmph = QueryString["windspeedavgmph"];
            heatindex = QueryString["heatindex"];
            feelslike = QueryString["feelslike"];
            windchill = QueryString["windchill"];
            dewptf = QueryString["dewptf"];
            dailyrainin = QueryString["dailyrainin"];
            rainin = QueryString["rainin"];
        }

        public string dateutc { get; private set; }
        public string id { get; private set; }
        public string mt { get; private set; }
        public string sensor { get; private set; }
        public string sensorbattery { get; private set; }
        public string rssi { get; private set; }
        public string hubbattery { get; private set; }
        public string baromin { get; private set; }
        public string humidity { get; private set; }
        public string tempf { get; private set; }
        public string windspeedmph { get; private set; }
        public string winddir { get; private set; }
        public string windgustmph { get; private set; }
        public string windgustdir { get; private set; }
        public string windspeedavgmph { get; private set; }
        public string heatindex { get; private set; }
        public string feelslike { get; private set; }
        public string windchill { get; private set; }
        public string dewptf { get; private set; }
        public string dailyrainin { get; private set; }
        public string rainin { get; private set; }
    }
}
