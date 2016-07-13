namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Params;
    using Utils;

    public class TraktMovieFilter : TraktCommonMovieAndShowFilter
    {
        public TraktMovieFilter() : base() { }

        public TraktMovieFilter(string query, int years, string[] genres = null, string[] languages = null,
                                string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                                string[] certifications = null)
            : base(query, years, genres, languages, countries, runtimes, ratings, certifications) { }

        public new TraktMovieFilter WithQuery(string query)
        {
            base.WithQuery(query);
            return this;
        }

        public new TraktMovieFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        public new TraktMovieFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        public new TraktMovieFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        public new TraktMovieFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        public new TraktMovieFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        public new TraktMovieFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        public new TraktMovieFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        public new TraktMovieFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        public new TraktMovieFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        public new TraktMovieFilter AddCertifications(string certification, params string[] certifications)
        {
            base.AddCertifications(certification, certifications);
            return this;
        }

        public new TraktMovieFilter WithCertifications(string certification, params string[] certifications)
        {
            base.WithCertifications(certification, certifications);
            return this;
        }
    }
}
