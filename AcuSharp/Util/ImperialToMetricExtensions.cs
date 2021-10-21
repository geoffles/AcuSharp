using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuSharp.Util
{
    public static class ImperialToMetricExtensions
    {
        public static double ToHpa(this double @in)
        {
            return Math.Round(@in * 33.86389, 3, MidpointRounding.AwayFromZero);
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
}
