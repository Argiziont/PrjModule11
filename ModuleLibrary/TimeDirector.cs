using System;
using System.Collections.Generic;
using System.IO;
using ModuleLibrary.Miscellaneous;

namespace ModuleLibrary
{
//    Samoa Standard Time

//    Hawaiian Standard Time

//    Alaskan Standard Time

//    Pacific Standard Time(Mexico)

//    Pacific Standard Time

    public class TimeDirector
    {
        public SortedSet<string> SortedDates { get; set; } = new();

        /// <summary>
        ///     Displays time in console and writes to file
        /// </summary>
        /// <param name="zone">Time Zone</param>
        /// <param name="mode">Mode for display</param>
        /// <param name="power">Numeral system</param>
        public void DisplayTime(string zone, TimeDisplayMode mode, int power = 10)
        {
            if (zone == null) throw new ArgumentNullException(nameof(zone));

            var dateTime = SortDate(GetTime(zone), power);

            SortedDates.Add(dateTime);

            // Create a file to write to.
            if (!File.Exists("TimeInfo.txt"))
                File.CreateText("TimeInfo.txt");

            switch (mode)
            {
                case TimeDisplayMode.ConsoleOnly:
                    Console.WriteLine(dateTime);

                    break;
                case TimeDisplayMode.FileOnly:
                    using (var fs = File.AppendText("TimeInfo.txt"))
                    {
                        fs.WriteLine(dateTime);
                    }

                    break;
                case TimeDisplayMode.BothConsoleAndFile:

                    Console.WriteLine(dateTime);
                    using (var fs = File.AppendText("TimeInfo.txt"))
                    {
                        fs.WriteLine(dateTime);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        /// <summary>
        ///     Sort by template
        /// </summary>
        /// <param name="dateTime">Current date</param>
        /// <param name="power">Numeral system</param>
        /// <returns></returns>
        private static string SortDate(DateTime dateTime, int power)
        {
            return $"{ArbitrarySystemChanger(dateTime.Millisecond, power)}:" +
                   $"{ArbitrarySystemChanger(dateTime.Second, power)}:" +
                   $"{ArbitrarySystemChanger(dateTime.Hour, power)} " +
                   $"{ArbitrarySystemChanger(dateTime.Day, power)}/" +
                   $"{ArbitrarySystemChanger(dateTime.Month, power)}/" +
                   $"{ArbitrarySystemChanger(dateTime.Year, power)}";
        }

        /// <summary>
        ///     Get current time for time zone
        /// </summary>
        private static DateTime GetTime(string zone)
        {
            TimeZoneInfo timeZone;
            try
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(zone);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        }

        /// <summary>
        /// Change numeral system for number
        /// </summary>
        private static string ArbitrarySystemChanger(int number, int radix)
        {
            const int bitsInLong = 64;
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > digits.Length)
                throw new Exception("The radix must be >= 2 and <= " + digits.Length);


            var index = bitsInLong - 1;
            long currentNumber = Math.Abs(number);
            var charArray = new char[bitsInLong];

            while (currentNumber != 0)
            {
                var remainder = (int) (currentNumber % radix);
                charArray[index--] = digits[remainder];
                currentNumber /= radix;
            }

            var result = new string(charArray, index + 1, bitsInLong - index - 1);
            return result;
        }
    }
}