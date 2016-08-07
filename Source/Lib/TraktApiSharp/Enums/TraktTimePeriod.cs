namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktTimePeriod
    {
        Unspecified,
        Weekly,
        Monthly,
        Yearly,
        All
    }

    public static class TraktPeriodExtensions
    {
        public static string AsString(this TraktTimePeriod period)
        {
            switch (period)
            {
                case TraktTimePeriod.Weekly: return "weekly";
                case TraktTimePeriod.Monthly: return "monthly";
                case TraktTimePeriod.Yearly: return "yearly";
                case TraktTimePeriod.All: return "all";
                case TraktTimePeriod.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(period.ToString());
            }
        }
    }
}
