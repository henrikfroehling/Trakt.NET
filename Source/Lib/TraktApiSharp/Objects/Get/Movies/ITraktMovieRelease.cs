namespace TraktApiSharp.Objects.Get.Movies
{
    using Enums;
    using System;

    public interface ITraktMovieRelease
    {
        string CountryCode { get; set; }

        string Certification { get; set; }

        DateTime? ReleaseDate { get; set; }

        TraktReleaseType ReleaseType { get; set; }

        string Note { get; set; }
    }
}
