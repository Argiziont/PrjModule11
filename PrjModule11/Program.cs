using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ModuleLibrary;
using ModuleLibrary.Miscellaneous;

namespace PrjModule11
{
    internal static class Program
    {
        private static void Main()
        {
            const string timeZone = "Pacific Standard Time";
            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;

            var charBuff = new StringBuffer("a bcd a");

            Console.WriteLine(
                $"comparison \" a bcd a \" and \" a bcd a\" without spaces equals:{charBuff.CompareTo("a bcd a ")}");
            Console.WriteLine(
                $"comparison \" a bcd a \" and \" a bcd a\" in reverse equals:{charBuff.CompareToReverse("a bcd a ")}");

            Console.WriteLine();

            #region DictionaryComparison

            var myDictionary = new MyDictionary<string, int>();
            var dictionary = new Dictionary<string, int>();

            var watch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 1000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 1000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 1000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();
            myDictionary = new MyDictionary<string, int>();

            for (var i = 0; i < 5000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 5000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 5000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 5000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();
            myDictionary = new MyDictionary<string, int>();

            for (var i = 0; i < 6000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 6000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 6000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 6000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();
            myDictionary = new MyDictionary<string, int>();

            for (var i = 0; i < 10000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 10000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 10000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 10000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();
            myDictionary = new MyDictionary<string, int>();

            for (var i = 0; i < 15000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 15000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 15000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 15000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();
            myDictionary = new MyDictionary<string, int>();

            for (var i = 0; i < 20000; i++) dictionary.Add(i.ToString(), i);
            Console.WriteLine("Dictionary add 20000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 20000; i++) myDictionary.Add(i.ToString(), i);
            Console.WriteLine("MyDictionary add 20000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++) dictionary.Remove(i.ToString());
            Console.WriteLine("Dictionary remove 1000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++) myDictionary.Remove(i.ToString());
            Console.WriteLine("MyDictionary remove 1000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            for (var i = 1000; i < 6000; i++) dictionary.Remove(i.ToString());
            Console.WriteLine("Dictionary remove 5000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 1000; i < 6000; i++) myDictionary.Remove(i.ToString());
            Console.WriteLine("MyDictionary remove 5000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            myDictionary = new MyDictionary<string, int>();
            dictionary = new Dictionary<string, int>();

            for (var i = 0; i < 5000; i++) dictionary.Add(i.ToString(), i);
            for (var i = 0; i < 5000; i++) myDictionary.Add(i.ToString(), i);


            for (var i = 0; i < 1000; i++) dictionary.ContainsKey(i.ToString());
            Console.WriteLine("Dictionary getByKey 1000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++) myDictionary.ContainsKey(i.ToString());
            Console.WriteLine("MyDictionary getByKey 1000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 5000; i++) dictionary.ContainsKey(i.ToString());
            Console.WriteLine("Dictionary getByKey 5000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 5000; i++) myDictionary.ContainsKey(i.ToString());
            Console.WriteLine("MyDictionary getByKey 5000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();


            for (var i = 0; i < 1000; i++) dictionary.ContainsValue(i);
            Console.WriteLine("Dictionary getByValue 1000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 1000; i++) myDictionary.Contains(new KeyValuePair<string, int>(i.ToString(), i));
            Console.WriteLine("MyDictionary getByValue 1000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 5000; i++) dictionary.ContainsValue(i);
            Console.WriteLine("Dictionary getByValue 5000 elements time: " + watch.ElapsedMilliseconds + "ms");
            watch = Stopwatch.StartNew();

            for (var i = 0; i < 5000; i++) myDictionary.Contains(new KeyValuePair<string, int>(i.ToString(), i));
            Console.WriteLine("MyDictionary getByValue 5000 elements time: " + watch.ElapsedMilliseconds + "ms\n");
            watch = Stopwatch.StartNew();

            #endregion


            var timeMng = new TimeDirector();
            Console.WriteLine("Write numeral system for data");
            var power = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\"ESC To Exit\"");

            do
            {
                while (!Console.KeyAvailable)
                    try
                    {
                        Parallel.Invoke(new ParallelOptions {CancellationToken = token},
                            () =>
                            {
                                timeMng.DisplayTime(timeZone, TimeDisplayMode.BothConsoleAndFile, power);
                                Thread.Sleep(1000);
                            }
                        );
                    }
                    catch
                    {
                        Console.WriteLine("You Exited");
                        cancelTokenSource.Dispose();
                        return;
                    }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);


            Console.WriteLine("You exited from loop");
        }
    }
}