namespace TraktApiSharp.Example.UWP.Models.ModelConverter
{
    using Objects.Get.Movies;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    public static class MovieModelConverter
    {
        public static T Convert<T>(ITraktMovie traktMovie) where T : TraktMovie, new()
        {
            if (traktMovie == null)
                return null;

            var movie = Activator.CreateInstance<T>();

            if (movie == null)
                return null;

            movie.AvailableTranslationLanguageCodes = traktMovie.AvailableTranslationLanguageCodes ?? new List<string>();
            movie.Certification = traktMovie.Certification ?? string.Empty;
            movie.Genres = traktMovie.Genres ?? new List<string>();
            movie.Homepage = traktMovie.Homepage ?? string.Empty;
            movie.LanguageCode = traktMovie.LanguageCode ?? string.Empty;
            movie.Overview = traktMovie.Overview ?? string.Empty;
            movie.Rating = traktMovie.Rating ?? 0.0f;
            movie.Runtime = traktMovie.Runtime ?? 0;
            movie.Tagline = traktMovie.Tagline ?? string.Empty;
            movie.Title = traktMovie.Title ?? string.Empty;
            movie.Trailer = traktMovie.Trailer ?? string.Empty;
            movie.Votes = traktMovie.Votes ?? 0;
            movie.Year = traktMovie.Year ?? 1900;
            movie.Ids = traktMovie.Ids;
            movie.Released = traktMovie.Released;
            movie.UpdatedAt = traktMovie.UpdatedAt;

            return movie as T;
        }
    }
}
