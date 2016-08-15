namespace TraktApiSharp.Example.UWP.Models.ModelConverter
{
    using Movies;
    using Objects.Basic;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    public static class MovieModelConverter
    {
        private const string DEFAULT_IMAGE = "ms-appx:///Assets/StoreLogo.jpg";

        public static TrendingMovie Convert(TraktTrendingMovie traktTrendingMovie)
        {
            if (traktTrendingMovie == null)
                return null;

            var movie = traktTrendingMovie.Movie;

            if (movie == null)
                return null;

            var trendingMovie = new TrendingMovie
            {
                AvailableTranslationLanguageCodes = movie.AvailableTranslationLanguageCodes ?? new List<string>(),
                Certification = movie.Certification ?? string.Empty,
                Genres = movie.Genres ?? new List<string>(),
                Homepage = movie.Homepage ?? string.Empty,
                LanguageCode = movie.LanguageCode ?? string.Empty,
                Overview = movie.Overview ?? string.Empty,
                Rating = movie.Rating ?? 0.0f,
                Runtime = movie.Runtime ?? 0,
                Tagline = movie.Tagline ?? string.Empty,
                Title = movie.Title ?? string.Empty,
                Trailer = movie.Trailer ?? string.Empty,
                Votes = movie.Votes ?? 0,
                Watchers = traktTrendingMovie.Watchers ?? 0,
                Year = movie.Year ?? 1900,
                Ids = movie.Ids,
                Released = movie.Released,
                UpdatedAt = movie.UpdatedAt
            };

            var traktImages = movie.Images;
            var images = new TraktMovieImages();

            if (traktImages != null)
            {
                if (traktImages.FanArt != null)
                {
                    images.FanArt = new TraktImageSet
                    {
                        Full = traktImages.FanArt.Full ?? DEFAULT_IMAGE,
                        Medium = traktImages.FanArt.Medium ?? DEFAULT_IMAGE,
                        Thumb = traktImages.FanArt.Thumb ?? DEFAULT_IMAGE
                    };
                }

                if (traktImages.Poster != null)
                {
                    images.Poster = new TraktImageSet
                    {
                        Full = traktImages.Poster.Full ?? DEFAULT_IMAGE,
                        Medium = traktImages.Poster.Medium ?? DEFAULT_IMAGE,
                        Thumb = traktImages.Poster.Thumb ?? DEFAULT_IMAGE
                    };
                }
            }
            else
            {
                images.FanArt = new TraktImageSet
                {
                    Full = DEFAULT_IMAGE,
                    Medium = DEFAULT_IMAGE,
                    Thumb = DEFAULT_IMAGE
                };

                images.Poster = new TraktImageSet
                {
                    Full = DEFAULT_IMAGE,
                    Medium = DEFAULT_IMAGE,
                    Thumb = DEFAULT_IMAGE
                };
            }

            trendingMovie.Images = images;
            return trendingMovie;
        }
    }
}
