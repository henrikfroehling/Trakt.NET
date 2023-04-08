namespace TraktNet.Extensions
{
    using System;

    /// <summary>Provides helper methods for datetimes.</summary>
    public static class DateTimeExtensions
    {
        /// <summary>Returns the minimum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimum datetime of the two given datetimes.</returns>
        public static DateTime Min(this DateTime value, DateTime? otherDate)
            => value.Min(otherDate.GetValueOrDefault());

        /// <summary>Returns the minimum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimum datetime of the two given datetimes.</returns>
        public static DateTime Min(this DateTime? value, DateTime otherDate)
            => otherDate.Min(value.GetValueOrDefault());

        /// <summary>Returns the minimum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimum datetime of the two given datetimes.</returns>
        public static DateTime Min(this DateTime? value, DateTime? otherDate)
            => value.GetValueOrDefault().Min(otherDate.GetValueOrDefault());

        /// <summary>Returns the minimum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimum datetime of the two given datetimes.</returns>
        public static DateTime Min(this DateTime value, DateTime otherDate)
            => value < otherDate ? value : otherDate;

        /// <summary>Returns the maximum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimummaximum datetime of the two given datetimes.</returns>
        public static DateTime Max(this DateTime value, DateTime? otherDate)
            => value.Max(otherDate.GetValueOrDefault());

        /// <summary>Returns the maximum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimummaximum datetime of the two given datetimes.</returns>
        public static DateTime Max(this DateTime? value, DateTime otherDate)
            => otherDate.Max(value.GetValueOrDefault());

        /// <summary>Returns the maximum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimummaximum datetime of the two given datetimes.</returns>
        public static DateTime Max(this DateTime? value, DateTime? otherDate)
            => value.GetValueOrDefault().Max(otherDate.GetValueOrDefault());

        /// <summary>Returns the maximum datetime of the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The minimummaximum datetime of the two given datetimes.</returns>
        public static DateTime Max(this DateTime value, DateTime otherDate)
            => value > otherDate ? value : otherDate;

        /// <summary>Returns the number of years between the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The number of years between the two given datetimes.</returns>
        public static int YearsBetween(this DateTime value, DateTime? otherDate)
            => value.YearsBetween(otherDate.GetValueOrDefault());

        /// <summary>Returns the number of years between the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The number of years between the two given datetimes.</returns>
        public static int YearsBetween(this DateTime? value, DateTime otherDate)
            => otherDate.YearsBetween(value.GetValueOrDefault());

        /// <summary>Returns the number of years between the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The number of years between the two given datetimes.</returns>
        public static int YearsBetween(this DateTime? value, DateTime? otherDate)
            => value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault());

        /// <summary>Returns the number of years between the two given datetimes.</summary>
        /// <param name="value">The first datetime, which will be compared to the second datetime.</param>
        /// <param name="otherDate">The second datetime, which will be compared to the first datetime.</param>
        /// <returns>The number of years between the two given datetimes.</returns>
        public static int YearsBetween(this DateTime value, DateTime otherDate)
            => Math.Abs(value.Year - otherDate.Year);

        /// <summary>Converts the given datetime to a string, containing only the date in the Trakt date format.</summary>
        /// <param name="value">The datetime, which should be converted. Will be automatically converted to universal (UTC) datetime.</param>
        /// <returns>A string, containing only the date in the Trakt date format.</returns>
        public static string ToTraktDateString(this DateTime value)
            => value.ToUniversalTime().ToString("yyyy-MM-dd");

        /// <summary>Converts the given datetime to a string, containing the datetime in the Trakt datetime format.</summary>
        /// <param name="value">The datetime, which should be converted. Will be automatically converted to universal (UTC) datetime.</param>
        /// <returns>A string, containing the datetime in the Trakt datetime format.</returns>
        public static string ToTraktLongDateTimeString(this DateTime value)
            => value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

        /// <summary>
        /// Converts the given datetime to a cache efficient string, containing the datetime in the Trakt datetime format,
        /// with minutes, seconds and milliseconds set to zero.
        /// </summary>
        /// <param name="value">The datetime, which should be converted. Will be automatically converted to universal (UTC) datetime.</param>
        /// <returns>A cache efficient string, containing the datetime in the Trakt datetime format, with minutes, seconds and milliseconds set to zero.</returns>
        public static string ToTraktCacheEfficientLongDateTimeString(this DateTime value)
        {
            var dateTime = new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0, 0);
            return dateTime.ToTraktLongDateTimeString();
        }
    }
}
