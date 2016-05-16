using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests
{
    using System;
    using System.Collections.Generic;
    public enum TraktExtendedOptionOld
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

    public class TraktExtendedOption
    {
        public TraktExtendedOption()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
        }

        public bool Minimal { get; set; }

        public bool Metadata { get; set; }

        public bool Images { get; set; }

        public bool Full { get; set; }

        public bool NoSeasons { get; set; }

        public TraktExtendedOption SetMinimal()
        {
            Minimal = true;
            return this;
        }

        public TraktExtendedOption ResetMinimal()
        {
            Minimal = false;
            return this;
        }

        public TraktExtendedOption SetMetadata()
        {
            Metadata = true;
            return this;
        }

        public TraktExtendedOption ResetMetadata()
        {
            Metadata = false;
            return this;
        }

        public TraktExtendedOption SetImages()
        {
            Images = true;
            return this;
        }

        public TraktExtendedOption ResetImages()
        {
            Images = false;
            return this;
        }

        public TraktExtendedOption SetFull()
        {
            Full = true;
            return this;
        }

        public TraktExtendedOption ResetFull()
        {
            Full = false;
            return this;
        }

        public TraktExtendedOption SetNoSeasons()
        {
            NoSeasons = true;
            return this;
        }

        public TraktExtendedOption ResetNoSeasons()
        {
            NoSeasons = false;
            return this;
        }

        public TraktExtendedOption SetAll()
        {
            Minimal = true;
            Metadata = true;
            Images = true;
            Full = true;
            NoSeasons = false;
            return this;
        }

        public TraktExtendedOption SetAllAndNoSeasons()
        {
            Minimal = true;
            Metadata = true;
            Images = true;
            Full = true;
            NoSeasons = true;
            return this;
        }

        public TraktExtendedOption Reset()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
            return this;
        }

        public IEnumerable<string> Resolve()
        {
            var options = new List<string>();

            if (Minimal)
                options.Add("min");

            if (Metadata)
                options.Add("metadata");

            if (Images)
                options.Add("images");

            if (Full)
                options.Add("full");

            if (NoSeasons)
                options.Add("noseasons");

            return options;
        }

        public override string ToString()
        {
            var options = Resolve();
            return string.Join(",", options);
        }
    }

    internal static class TraktExtendedOptionExtensions
    {
        internal static string AsString(this TraktExtendedOptionOld extendedOption)
        {
            switch (extendedOption)
            {
                case TraktExtendedOptionOld.Unspecified: return string.Empty;
                case TraktExtendedOptionOld.Minimal: return "min";
                case TraktExtendedOptionOld.Metadata: return "metadata";
                case TraktExtendedOptionOld.Images: return "images";
                case TraktExtendedOptionOld.Full: return "full";
                case TraktExtendedOptionOld.FullAndImages: return "full,images";
                case TraktExtendedOptionOld.NoSeasons: return "noseasons";
                case TraktExtendedOptionOld.MinimalAndNoSeasons: return "min,noseasons";
                case TraktExtendedOptionOld.MetadataAndNoSeasons: return "metadata,noseasons";
                case TraktExtendedOptionOld.ImagesAndNoSeasons: return "images,noseasons";
                case TraktExtendedOptionOld.FullAndNoSeasons: return "full,noseasons";
                case TraktExtendedOptionOld.FullAndImagesAndNoSeasons: return "full,images,noseasons";
                default:
                    throw new NotSupportedException(extendedOption.ToString());
            }
        }
    }
}
