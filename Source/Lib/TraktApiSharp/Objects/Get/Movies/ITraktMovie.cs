namespace TraktApiSharp.Objects.Get.Movies
{
    using System;
    using System.Collections.Generic;

    public interface ITraktMovie
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }

        string Tagline { get; set; }

        string Overview { get; set; }

        DateTime? Released { get; set; }

        int? Runtime { get; set; }

        string Trailer { get; set; }

        string Homepage { get; set; }

        float? Rating { get; set; }

        int? Votes { get; set; }

        DateTime? UpdatedAt { get; set; }

        string LanguageCode { get; set; }

        IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        IEnumerable<string> Genres { get; set; }

        string Certification { get; set; }

        string CountryCode { get; set; }

        int? CommentCount { get; set; }
    }
}
