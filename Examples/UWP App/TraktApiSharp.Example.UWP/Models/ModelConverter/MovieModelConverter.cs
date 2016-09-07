namespace TraktApiSharp.Example.UWP.Models.ModelConverter
{
    using Objects.Basic;
    using Objects.Get.Movies;
    using System;
    using System.Collections.Generic;

    public static class MovieModelConverter
    {
        private const string DEFAULT_IMAGE = "ms-appx:///Assets/StoreLogo.jpg";

        public static T Convert<T>(TraktMovie traktMovie) where T : TraktMovie, new()
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

            movie.Images = GetImages(traktMovie);

            return movie as T;
        }

        private static TraktMovieImages GetImages(TraktMovie traktMovie)
        {
            var traktImages = traktMovie.Images;
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
                images.FanArt = new TraktImageSet { Full = DEFAULT_IMAGE, Medium = DEFAULT_IMAGE, Thumb = DEFAULT_IMAGE };
                images.Poster = new TraktImageSet { Full = DEFAULT_IMAGE, Medium = DEFAULT_IMAGE, Thumb = DEFAULT_IMAGE };
            }

            return images;
        }
    }
}
