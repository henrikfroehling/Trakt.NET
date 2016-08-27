namespace TraktApiSharp.Example.UWP.Models.ModelConverter
{
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows;
    using System;
    using System.Collections.Generic;

    public static class ShowModelConverter
    {
        private const string DEFAULT_IMAGE = "ms-appx:///Assets/StoreLogo.jpg";

        public static T Convert<T>(TraktShow traktShow) where T : TraktShow, new()
        {
            if (traktShow == null)
                return null;

            var show = Activator.CreateInstance<T>();

            if (show == null)
                return null;

            show.AvailableTranslationLanguageCodes = traktShow.AvailableTranslationLanguageCodes ?? new List<string>();
            show.Certification = traktShow.Certification ?? string.Empty;
            show.Genres = traktShow.Genres ?? new List<string>();
            show.Homepage = traktShow.Homepage ?? string.Empty;
            show.LanguageCode = traktShow.LanguageCode ?? string.Empty;
            show.Overview = traktShow.Overview ?? string.Empty;
            show.Rating = traktShow.Rating ?? 0.0f;
            show.Runtime = traktShow.Runtime ?? 0;
            show.Title = traktShow.Title ?? string.Empty;
            show.Trailer = traktShow.Trailer ?? string.Empty;
            show.Votes = traktShow.Votes ?? 0;
            show.Year = traktShow.Year ?? 1900;
            show.Ids = traktShow.Ids;
            show.UpdatedAt = traktShow.UpdatedAt;
            show.AiredEpisodes = traktShow.AiredEpisodes ?? 0;
            show.CountryCode = traktShow.CountryCode ?? string.Empty;
            show.FirstAired = traktShow.FirstAired;
            show.Network = traktShow.Network ?? string.Empty;
            show.Status = traktShow.Status ?? TraktShowStatus.Unspecified;

            show.Images = GetImages(traktShow);

            return show as T;
        }

        private static TraktShowImages GetImages(TraktShow traktShow)
        {
            var traktImages = traktShow.Images;
            var images = new TraktShowImages();

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
