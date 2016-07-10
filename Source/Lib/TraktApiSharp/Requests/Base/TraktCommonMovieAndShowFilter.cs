namespace TraktApiSharp.Requests.Base
{
    using System;
    using System.Collections.Generic;

    public abstract class TraktCommonMovieAndShowFilter : TraktCommonFilter
    {
        protected TraktCommonMovieAndShowFilter() : base() { }

        protected TraktCommonMovieAndShowFilter(string query, int years, string[] genres = null, string[] languages = null,
                                                string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null,
                                                string[] certifications = null)
            : base(years, genres, languages, countries, runtimes, ratings)
        {
            WithQuery(query);
            WithCertifications(null, certifications);
        }

        public string Query { get; protected set; }

        public bool HasQuerySet => !string.IsNullOrEmpty(Query);

        public string[] Certifications { get; private set; }

        public bool HasCertificationsSet => Certifications != null && Certifications.Length > 0;

        public override bool HasValues => base.HasValues || HasQuerySet || HasCertificationsSet;

        public TraktCommonMovieAndShowFilter WithQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("query not valid", nameof(query));

            Query = query;
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        public new TraktCommonMovieAndShowFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        public new TraktCommonMovieAndShowFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        public new TraktCommonMovieAndShowFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        public new TraktCommonMovieAndShowFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        public TraktCommonMovieAndShowFilter AddCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(true, certification, certifications);
        }

        public TraktCommonMovieAndShowFilter WithCertifications(string certification, params string[] certifications)
        {
            return AddCertifications(false, certification, certifications);
        }

        public override void Clear()
        {
            base.Clear();
            Query = null;
            Certifications = null;
        }

        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasQuerySet)
                parameters.Add("query", Query);

            if (HasCertificationsSet)
                parameters.Add("certifications", string.Join(",", Certifications));

            return parameters;
        }

        private TraktCommonMovieAndShowFilter AddCertifications(bool keepExisting, string certification, params string[] certifications)
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
