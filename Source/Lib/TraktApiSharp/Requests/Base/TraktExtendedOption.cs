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
        FullAndImages
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
                default:
                    throw new NotSupportedException(extendedOption.ToString());
            }
        }
    }
}
