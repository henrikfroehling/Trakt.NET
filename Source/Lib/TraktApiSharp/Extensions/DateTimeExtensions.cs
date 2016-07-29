namespace TraktApiSharp.Extensions
{
    using System;

    /// <summary>Provides helper methods for datetimes.</summary>
    public static class DateTimeExtensions
    {
        public static DateTime Min(this DateTime value, DateTime? otherDate)
        {
            return value.Min(otherDate.GetValueOrDefault());
        }

        public static DateTime Min(this DateTime? value, DateTime otherDate)
        {
            return otherDate.Min(value.GetValueOrDefault());
        }

        public static DateTime Min(this DateTime? value, DateTime? otherDate)
        {
            return value.GetValueOrDefault().Min(otherDate.GetValueOrDefault());
        }

        public static DateTime Min(this DateTime value, DateTime otherDate)
        {
            return value < otherDate ? value : otherDate;
        }

        public static DateTime Max(this DateTime value, DateTime? otherDate)
        {
            return value.Max(otherDate.GetValueOrDefault());
        }

        public static DateTime Max(this DateTime? value, DateTime otherDate)
        {
            return otherDate.Max(value.GetValueOrDefault());
        }

        public static DateTime Max(this DateTime? value, DateTime? otherDate)
        {
            return value.GetValueOrDefault().Max(otherDate.GetValueOrDefault());
        }

        public static DateTime Max(this DateTime value, DateTime otherDate)
        {
            return value > otherDate ? value : otherDate;
        }

        public static int YearsBetween(this DateTime value, DateTime? otherDate)
        {
            return value.YearsBetween(otherDate.GetValueOrDefault());
        }

        public static int YearsBetween(this DateTime? value, DateTime otherDate)
        {
            return otherDate.YearsBetween(value.GetValueOrDefault());
        }

        public static int YearsBetween(this DateTime? value, DateTime? otherDate)
        {
            return value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault());
        }

        public static int YearsBetween(this DateTime value, DateTime otherDate)
        {
            return (new DateTime(1, 1, 1) + (value.Max(otherDate) - value.Min(otherDate))).Year - 1;
        }

        /// <summary>Converts the given datetime to a string, containing only the date in the Trakt date format.</summary>
        /// <param name="value">The datetime, which should be converted. Will be automatically converted to universal (UTC) datetime.</param>
        /// <returns>A string, containing only the date in the Trakt date format.</returns>
        public static string ToTraktDateString(this DateTime value)
        {
            return value.ToUniversalTime().ToString("yyyy-MM-dd");
        }

        /// <summary>Converts the given datetime to a string, containing the datetime in the Trakt datetime format.</summary>
        /// <param name="value">The datetime, which should be converted. Will be automatically converted to universal (UTC) datetime.</param>
        /// <returns>A string, containing the datetime in the Trakt datetime format.</returns>
        public static string ToTraktLongDateTimeString(this DateTime value)
        {
            return value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
