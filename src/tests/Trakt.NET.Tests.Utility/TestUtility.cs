using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace TraktNET
{
    public static class TestUtility
    {
        private static string? _location;

        public static async Task<T?> DeserializeJsonAsync<T>(string jsonFilename)
        {
            string filepath = GetJsonFilepath(jsonFilename);
            using var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<T>(stream, Constants.Json.JsonSettings);
        }

        public static DateTime ParseUTCDateTime(string dateTime)
            => DateTime.Parse(dateTime, CultureInfo.InvariantCulture).ToUniversalTime();

        public static DateOnly ParseDate(string date) => DateOnly.Parse(date, CultureInfo.InvariantCulture);

        public static TimeOnly ParseTime(string time) => TimeOnly.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);

        private static string GetJsonFilepath(string jsonFilename)
            => Path.Combine(GetLocation(), Path.Combine("JsonData", jsonFilename));

        private static string GetLocation()
        {
            if (!string.IsNullOrWhiteSpace(_location))
                return _location!;

            _location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return _location!;
        }
    }
}
