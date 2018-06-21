namespace TraktNet.Objects.Get.Episodes
{
    using System;
    using System.Collections.Generic;

    public interface ITraktEpisode
    {
        int? SeasonNumber { get; set; }

        int? Number { get; set; }

        string Title { get; set; }

        ITraktEpisodeIds Ids { get; set; }

        int? NumberAbsolute { get; set; }

        string Overview { get; set; }

        int? Runtime { get; set; }

        float? Rating { get; set; }

        int? Votes { get; set; }

        DateTime? FirstAired { get; set; }

        DateTime? UpdatedAt { get; set; }

        IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        IEnumerable<ITraktEpisodeTranslation> Translations { get; set; }

        int? CommentCount { get; set; }
    }
}
