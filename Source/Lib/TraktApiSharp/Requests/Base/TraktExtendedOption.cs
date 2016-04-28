using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests
{
    using System;

    public enum TraktExtendedOption
    {
        Unspecified,
        Minimal,
        Metadata,
        Images,
        Full,
        FullAndImages,
        NoSeasons,
        MinimalAndNoSeasons,
        MetadataAndNoSeasons,
        ImagesAndNoSeasons,
        FullAndNoSeasons,
        FullAndImagesAndNoSeasons
    }

    internal static class TraktExtendedOptionExtensions
    {
        internal static string AsString(this TraktExtendedOption extendedOption)
        {
            switch (extendedOption)
            {
                case TraktExtendedOption.Unspecified: return string.Empty;
                case TraktExtendedOption.Minimal: return "min";
                case TraktExtendedOption.Metadata: return "metadata";
                case TraktExtendedOption.Images: return "images";
                case TraktExtendedOption.Full: return "full";
                case TraktExtendedOption.FullAndImages: return "full,images";
                case TraktExtendedOption.NoSeasons: return "noseasons";
                case TraktExtendedOption.MinimalAndNoSeasons: return "min,noseasons";
                case TraktExtendedOption.MetadataAndNoSeasons: return "metadata,noseasons";
                case TraktExtendedOption.ImagesAndNoSeasons: return "images,noseasons";
                case TraktExtendedOption.FullAndNoSeasons: return "full,noseasons";
                case TraktExtendedOption.FullAndImagesAndNoSeasons: return "full,images,noseasons";
                default:
                    throw new NotSupportedException(extendedOption.ToString());
            }
        }
    }
}
