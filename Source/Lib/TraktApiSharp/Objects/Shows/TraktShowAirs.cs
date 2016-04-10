namespace TraktApiSharp.Objects.Shows
{
    using Core;
    using Newtonsoft.Json;
    using NodaTime;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The air time of a Trakt show.
    /// </summary>
    public class TraktShowAirs
    {
        private static List<string> DAYS = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        /// <summary>
        /// The day of week on which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "day")]
        public string Day { get; set; }

        /// <summary>
        /// The time of day at which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        /// <summary>
        /// The time zone id (Olson) for the location in which the show airs.
        /// </summary>
        [JsonProperty(PropertyName = "timezone")]
        public string TimeZoneId { get; set; }

        /// <summary>
        /// The time zone for the location in which the show airs.
        /// </summary>
        [JsonIgnore]
        public DateTimeZone TimeZone
        {
            get
            {
                return !string.IsNullOrEmpty(TimeZoneId) ? TraktTimeZone.FromOlsonTimeZoneId(TimeZoneId) : default(DateTimeZone);
            }
        }

        /// <summary>
        /// The day of week on which the show airs in local time.
        /// </summary>
        [JsonIgnore]
        public string LocalDay
        {
            get
            {
                if (!IsDayTimeFormatValid())
                    return string.Empty;

                var dayIndex = DAYS.IndexOf(Day);
                var hours = ParseHours();
                var minutes = ParseMinutes();

                if (minutes > 60)
                    ++hours;
                else if (minutes < 0)
                    --hours;

                if (hours < 0)
                    return dayIndex > 0 ? DAYS[dayIndex - 1] : DAYS[DAYS.Count - 1];

                if (hours > 24)
                    return dayIndex < 6 ? DAYS[dayIndex + 1] : DAYS[0];

                return Day;
            }
        }

        /// <summary>
        /// The time of day at which the show airs in local time.
        /// </summary>
        [JsonIgnore]
        public string LocalTime
        {
            get
            {
                if (!IsDayTimeFormatValid())
                    return string.Empty;

                var hours = ParseHours();
                var minutes = ParseMinutes();

                if (minutes > 60)
                {
                    minutes -= 60;
                    ++hours;
                }
                else if (minutes < 0)
                {
                    minutes += 60;
                    --hours;
                }

                if (hours < 0)
                    hours += 24;

                if (hours > 24)
                    hours -= 24;

                return string.Format("{0:00}:{1:00}", hours, minutes);
            }
        }

        private double TimeZoneOffsetMinutes =>
            TimeZone == null
            ? 0.0
            // FIXME ???
            : TimeZone.AtLeniently(LocalDateTime.FromDateTime(DateTime.Now)).ToDateTimeOffset().Minute - TimeZone.GetUtcOffset(Instant.FromDateTimeUtc(DateTime.UtcNow)).ToTimeSpan().Minutes;

        private bool IsDayTimeFormatValid() => !string.IsNullOrEmpty(Day) && !string.IsNullOrEmpty(Time)
                                                && Regex.IsMatch(Time, @"\d{2}:\d{2}") && TimeZone != null
                                                && DAYS.Contains(Day);

        private int ParseHours() => Int32.Parse(Time.Substring(0, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes / 60);

        private int ParseMinutes() => Int32.Parse(Time.Substring(3, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes % 60);
    }
}
