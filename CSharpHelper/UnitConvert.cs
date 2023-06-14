using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHelper
{
    public class UnitConvert
    {
        public static double MeterToFeet(double meter)
        {
            return meter * 3.2808399;
        }
        public static double FeetToMeter(double feet)
        {
            return feet / 3.2808399;
        }

        public static double KilometerToMile(double kilometer)
        {
            return kilometer * 1.609344;
        }
        public static double MileToKilometer(double mile)
        {
            return mile / 1.609344;
        }
    
        public static int SecondsToMinutes(int seconds)
        {
            return seconds * 60;
        }
        public static int MinutesToSeconds(int minutes)
        {
            return minutes / 60;
        }

        public static int SecondsToHours(int seconds)
        {
            return seconds * 3600;
        }
        public static int HoursToSeconds(int minutes)
        {
            return minutes / 3600;
        }
    }

    public enum Length
    {
        Meter, Decimeter, Centimeter, Millimeter
    }
}
