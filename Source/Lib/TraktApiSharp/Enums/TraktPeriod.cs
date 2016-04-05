namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktPeriod
    {
        Weekly,
        Monthly,
        Yearly,
        All
    }

    public static class TraktPeriodExtensions
    {
        public static string AsString(this TraktPeriod scope)
        {
            switch (scope)
            {
                case TraktPeriod.Weekly: return "weekly";
                case TraktPeriod.Monthly: return "monthly";
                case TraktPeriod.Yearly: return "yearly";
                case TraktPeriod.All: return "all";
                default:
                    throw new ArgumentOutOfRangeException("Period");
            }
        }
    }
}
