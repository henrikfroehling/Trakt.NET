namespace TraktApiSharp.Objects.Get.Shows
{
    using Enums;
    using Seasons;
    using System;
    using System.Collections.Generic;

    public interface ITraktShow
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktShowIds Ids { get; set; }

        string Overview { get; set; }

        DateTime? FirstAired { get; set; }

        ITraktShowAirs Airs { get; set; }

        int? Runtime { get; set; }

        string Certification { get; set; }

        string Network { get; set; }

        string CountryCode { get; set; }

        string Trailer { get; set; }

        string Homepage { get; set; }

        TraktShowStatus Status { get; set; }

        float? Rating { get; set; }

        int? Votes { get; set; }

        DateTime? UpdatedAt { get; set; }

        string LanguageCode { get; set; }

        IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        IEnumerable<string> Genres { get; set; }

        int? AiredEpisodes { get; set; }

        IEnumerable<ITraktSeason> Seasons { get; set; }
    }
}
