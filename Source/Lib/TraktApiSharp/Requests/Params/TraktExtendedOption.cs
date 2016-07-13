namespace TraktApiSharp.Requests.Params
{
    using System.Collections.Generic;

    public class TraktExtendedOption
    {
        public TraktExtendedOption()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
        }

        public bool Minimal { get; set; }

        public bool Metadata { get; set; }

        public bool Images { get; set; }

        public bool Full { get; set; }

        public bool NoSeasons { get; set; }

        public bool Episodes { get; set; }

        public bool HasAnySet => Minimal || Metadata || Images || Full || NoSeasons || Episodes;

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

        public TraktExtendedOption SetEpisodes()
        {
            Episodes = true;
            return this;
        }

        public TraktExtendedOption ResetEpisodes()
        {
            Episodes = false;
            return this;
        }

        public TraktExtendedOption Reset()
        {
            Minimal = false;
            Metadata = false;
            Images = false;
            Full = false;
            NoSeasons = false;
            Episodes = false;
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

            if (Episodes)
                options.Add("episodes");

            return options;
        }

        public override string ToString()
        {
            var options = Resolve();
            return string.Join(",", options);
        }
    }
}
