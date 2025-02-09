using System.Globalization;
using System.Reflection;
using System.Text.Json;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace TraktNET
{
    public static class TestUtility
    {
#if NET6_0_OR_GREATER
        static TestUtility()
            => JsonSerializerContextFactoryRegistry.RegisterFactory(Constants.Json.FactoryKey, new JsonSerializerContextFactory());
#endif

        private static string? _location;

        public static async Task<string> GetJsonFileContentAsync(string jsonFilename)
        {
            string filepath = GetJsonFilepath(jsonFilename);
            using StreamReader reader = File.OpenText(filepath);
            return await reader.ReadToEndAsync();
        }

        public static async Task<T?> DeserializeJsonAsync<T>(string jsonFilename) where T : class
        {
            string filepath = GetJsonFilepath(jsonFilename);
            using var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.GetContext<T>(Constants.Json.FactoryKey);
            return await JsonSerializer.DeserializeAsync(stream, typeof(T), jsonSerializerContext) as T;
#else
            return await JsonSerializer.DeserializeAsync<T>(stream, Constants.Json.JsonOptions);
#endif
        }

        public static async Task<IReadOnlyList<T>?> DeserializeJsonListAsync<T>(string jsonFilename) where T : class
        {
            string filepath = GetJsonFilepath(jsonFilename);
            using var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactoryRegistry.GetContext<T>(Constants.Json.FactoryKey);
            return await JsonSerializer.DeserializeAsync(stream, typeof(IReadOnlyList<T>), jsonSerializerContext) as IReadOnlyList<T>;
#else
            return await JsonSerializer.DeserializeAsync<IReadOnlyList<T>>(stream, Constants.Json.JsonOptions);
#endif
        }

        public static DateTime ParseUTCDateTime(string dateTime)
            => DateTime.Parse(dateTime, CultureInfo.InvariantCulture).ToUniversalTime();

#if NET7_0_OR_GREATER
        public static DateOnly ParseDate(string date) => DateOnly.Parse(date, CultureInfo.InvariantCulture);

        public static TimeOnly ParseTime(string time) => TimeOnly.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
#endif

        private static string GetJsonFilepath(string jsonFilename)
            => Path.Combine(GetLocation(), Path.Combine("..\\..\\..\\..\\JsonData", jsonFilename));

        private static string GetLocation()
        {
            if (!string.IsNullOrWhiteSpace(_location))
            {
                return _location!;
            }

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
            _location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            // Known issue in 4.x.x .NET versions.
            // Filepaths do not work with URIs.
            // This is a workaround.
            _location = _location.Replace("file:\\", string.Empty);
#else
            _location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#endif

            return _location!;
        }
    }
}
