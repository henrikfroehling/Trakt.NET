namespace TraktApiSharp.Requests
{
    using System;

    public enum TraktExtendedOption
    {
        Unspecified,
        Minimal,
        MinimalAndEpisodes,   // only for seasons
        Metadata,
        MetadataAndEpisodes,   // only for seasons
        Images,
        ImagesAndEpisodes,   // only for seasons
        Full,
        FullAndEpisodes,   // only for seasons
        FullAndImages,
        FullAndImagesAndEpisodes   // only for seasons
    }

    internal static class TraktExtendedOptionExtensions
    {
        internal static string AsString(this TraktExtendedOption scope)
        {
            switch (scope)
            {
                case TraktExtendedOption.Unspecified: return "";
                case TraktExtendedOption.Minimal: return "min";
                case TraktExtendedOption.MinimalAndEpisodes: return "min,episodes";
                case TraktExtendedOption.Metadata: return "metadata";
                case TraktExtendedOption.MetadataAndEpisodes: return "metadata,episodes";
                case TraktExtendedOption.Images: return "images";
                case TraktExtendedOption.ImagesAndEpisodes: return "images,episodes";
                case TraktExtendedOption.Full: return "full";
                case TraktExtendedOption.FullAndEpisodes: return "full,episodes";
                case TraktExtendedOption.FullAndImages: return "full,images";
                case TraktExtendedOption.FullAndImagesAndEpisodes: return "full,images,episodes";
                default:
                    throw new ArgumentOutOfRangeException("ExtendedOption");
            }
        }
    }
}
