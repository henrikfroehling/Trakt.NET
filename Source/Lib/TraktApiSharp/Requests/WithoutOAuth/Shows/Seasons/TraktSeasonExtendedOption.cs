using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using System;

    public enum TraktSeasonExtendedOption
    {
        Unspecified,
        Minimal,
        MinimalAndEpisodes,
        Metadata,
        MetadataAndEpisodes,
        Images,
        ImagesAndEpisodes,
        Full,
        FullAndEpisodes,
        FullAndImages,
        FullAndImagesAndEpisodes
    }

    internal static class TraktSeasonExtendedOptionExtensions
    {
        internal static string AsString(this TraktSeasonExtendedOption seasonExtendedOption)
        {
            switch (seasonExtendedOption)
            {
                case TraktSeasonExtendedOption.Unspecified: return string.Empty;
                case TraktSeasonExtendedOption.Minimal: return "min";
                case TraktSeasonExtendedOption.MinimalAndEpisodes: return "min,episodes";
                case TraktSeasonExtendedOption.Metadata: return "metadata";
                case TraktSeasonExtendedOption.MetadataAndEpisodes: return "metadata,episodes";
                case TraktSeasonExtendedOption.Images: return "images";
                case TraktSeasonExtendedOption.ImagesAndEpisodes: return "images,episodes";
                case TraktSeasonExtendedOption.Full: return "full";
                case TraktSeasonExtendedOption.FullAndEpisodes: return "full,episodes";
                case TraktSeasonExtendedOption.FullAndImages: return "full,images";
                case TraktSeasonExtendedOption.FullAndImagesAndEpisodes: return "full,images,episodes";
                default:
                    throw new NotSupportedException(seasonExtendedOption.ToString());
            }
        }
    }
}
