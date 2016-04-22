namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktHiddenItemsSection
    {
        Unspecified,
        Calendar,
        ProgressWatched,
        ProgressCollected,
        Recommendations
    }

    public static class TraktHiddenItemsSectionExtensions
    {
        public static string AsString(this TraktHiddenItemsSection hiddenItemsSection)
        {
            switch (hiddenItemsSection)
            {
                case TraktHiddenItemsSection.Calendar: return "calendar";
                case TraktHiddenItemsSection.ProgressWatched: return "progress_watched";
                case TraktHiddenItemsSection.ProgressCollected: return "progress_collected";
                case TraktHiddenItemsSection.Recommendations: return "recommendations";
                case TraktHiddenItemsSection.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(hiddenItemsSection.ToString());
            }
        }
    }
}
