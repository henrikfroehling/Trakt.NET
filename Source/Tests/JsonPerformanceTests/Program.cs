namespace JsonPerformanceTests
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using TraktApiSharp.Objects.Get.Shows;

    class Program
    {
        private static readonly JsonSerializerSettings DEFAULT_JSON_SETTINGS
               = new JsonSerializerSettings
               {
                   Formatting = Formatting.None,
                   NullValueHandling = NullValueHandling.Ignore
               };

        private const int ROUNDS = 10;

        static void Main(string[] args)
        {
            var json = ReadJson();

            if (string.IsNullOrEmpty(json))
                return;

            var convertResult = TestJsonConvert(json, ROUNDS);
            var readerResult = TestJsonReader(json, ROUNDS);

            WriteResults(convertResult, readerResult);

            Console.ReadKey();
        }

        private static double TestJsonConvert(string json, int rounds)
        {
            if (string.IsNullOrEmpty(json))
                return 0.0;

            double results = 0.0;

            for (int i = 0; i < rounds; i++)
            {
                var watch = Stopwatch.StartNew();
                var trendingShows = JsonConvert.DeserializeObject<IEnumerable<TraktTrendingShow>>(json, DEFAULT_JSON_SETTINGS);
                watch.Stop();

                results += watch.Elapsed.TotalMilliseconds;
            }

            var result = results / rounds;
            Console.WriteLine($"{nameof(TestJsonConvert)} Time: {result} ms");
            return result;
        }

        private static double TestJsonReader(string json, int rounds)
        {
            if (string.IsNullOrEmpty(json))
                return 0.0;

            var reader = new TrendingShowsReader();
            double results = 0.0;

            for (int i = 0; i < rounds; i++)
            {
                var watch = Stopwatch.StartNew();
                var trendingShows = reader.ReadTrendingShows(json);
                watch.Stop();

                results += watch.Elapsed.TotalMilliseconds;
            }

            var result = results / rounds;
            Console.WriteLine($"{nameof(TestJsonReader)} Time: {result} ms");
            return result;
        }

        private static string ReadJson()
        {
            const string fileName = "TrendingShows.json";

            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    var content = reader.ReadToEnd();
                    return content;
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Error in {nameof(ReadJson)}: {ex.Message}");
                return string.Empty;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error in {nameof(ReadJson)}: {ex.Message}");
                return string.Empty;
            }
        }

        private static void WriteResults(double convertResult, double readerResult)
        {
            try
            {
                using (var writer = new StreamWriter("JsonPerformanceResults.txt"))
                {
                    writer.WriteLine($"{nameof(TestJsonConvert)} Time: {convertResult} ms");
                    writer.WriteLine($"{nameof(TestJsonReader)} Time: {readerResult} ms");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error in {nameof(WriteResults)}: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error in {nameof(WriteResults)}: {ex.Message}");
            }
        }
    }
}
