namespace TraktApiSharp.Requests.Params
{
    using Utils;

    public class TraktSearchFilter : TraktCommonFilter
    {
        public TraktSearchFilter() : base() { }

        public TraktSearchFilter(int years, string[] genres = null, string[] languages = null,
                                 string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null)
            : base(years, genres, languages, countries, runtimes, ratings) { }

        public new TraktSearchFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        public new TraktSearchFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        public new TraktSearchFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        public new TraktSearchFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        public new TraktSearchFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        public new TraktSearchFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        public new TraktSearchFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        public new TraktSearchFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        public new TraktSearchFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }
    }
}
