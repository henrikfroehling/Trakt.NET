namespace TraktApiSharp.Core
{
    using NodaTime;
    using System;

    internal static class TraktTimeZone
    {
        internal static DateTimeZone FromOlsonTimeZoneId(string olsonTimeZoneId)
        {
            if (string.IsNullOrEmpty(olsonTimeZoneId))
                throw new ArgumentNullException("olsonTimeZoneId", "Olson time zone not valid");

            return DateTimeZoneProviders.Tzdb.GetZoneOrNull(olsonTimeZoneId);
        }
    }
}
