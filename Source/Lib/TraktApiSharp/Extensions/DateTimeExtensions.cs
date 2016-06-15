namespace TraktApiSharp.Extensions
{
    using System;

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

        public static string ToTraktDateString(this DateTime value)
        {
            return value.ToUniversalTime().ToString("yyyy-MM-dd");
        }

        public static string ToTraktLongDateTimeString(this DateTime value)
        {
            return value.ToUniversalTime().ToString("yyyy-MM-ddThh:mm:ss.fffZ");
        }
    }
}
