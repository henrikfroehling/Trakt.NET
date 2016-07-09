namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base;
    using System.Collections.Generic;

    public class TraktMovieFilter : TraktFilter
    {
        public TraktMovieFilter() { }

        public TraktMovieFilter(string query, int years, string[] genres = null, string[] languages = null,
                                string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                                string[] certifications = null) : base(query, years, genres, languages, countries, runtimes, ratings)
        {
            WithCertifications(null, certifications);
        }

        public string[] Certifications { get; private set; }

        public bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;

        public override bool HasValues => base.HasValues || HasCertificationsSet;

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

        public TraktMovieFilter AddCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(true, certification, certifications);
        }

        public TraktMovieFilter WithCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(false, certification, certifications);
        }

        public override void Clear()
        {
            base.Clear();
            Certifications = null;
        }

        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasCertificationsSet)
                parameters.Add("certifications", string.Join(",", Certifications));

            return parameters;
        }

        private TraktMovieFilter AddCertifications(bool keepExisting, string certification, params string[] certifications)
        {
            var certificationsList = new List<string>();

            if (keepExisting && this.Certifications != null && this.Certifications.Length > 0)
                certificationsList.AddRange(this.Certifications);

            if (!string.IsNullOrEmpty(certification))
                certificationsList.Add(certification);

            if (certifications != null && certifications.Length > 0)
                certificationsList.AddRange(certifications);

            this.Certifications = certificationsList.ToArray();

            return this;
        }
    }
}
