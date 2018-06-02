namespace TraktApiSharp.Objects.Get.Calendars
{
    using Episodes;
    using System;
    using System.Collections.Generic;

    public interface ITraktCalendarEpisode
    {
        int? SeasonNumber { get; set; }

        int? EpisodeNumber { get; set; }

        string EpisodeTitle { get; set; }

        ITraktEpisodeIds EpisodeIds { get; set; }

        int? AbsoluteEpisodeNumber { get; set; }

        string EpisodeOverview { get; set; }

        int? EpisodeRuntime { get; set; }

        float? EpisodeRating { get; set; }

        int? EpisodeVotes { get; set; }

        DateTime? EpisodeAiredFirstAt { get; set; }

        DateTime? EpisodeUpdatedAt { get; set; }

        IEnumerable<string> AvailableEpisodeTranslationLanguageCodes { get; set; }

        IEnumerable<ITraktEpisodeTranslation> EpisodeTranslations { get; set; }

        int? EpisodeCommentCount { get; set; }
    }
}
