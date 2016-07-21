namespace TraktApiSharp.Requests.Params
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public class TraktCalendarFilter : TraktCommonFilter
    {
        public TraktCalendarFilter() : base() { }

        public TraktCalendarFilter(string query, int years, string[] genres = null, string[] languages = null,
                                   string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null)
            : base(years, genres, languages, countries, runtimes, ratings)
        {
            WithQuery(query);
        }

        public string Query { get; protected set; }

        public bool HasQuerySet => !string.IsNullOrEmpty(Query);

        public override bool HasValues => base.HasValues || HasQuerySet;

        public TraktCalendarFilter WithQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("query not valid", nameof(query));

            Query = query;
            return this;
        }

        public new TraktCalendarFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        public new TraktCalendarFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        public new TraktCalendarFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        public new TraktCalendarFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        public new TraktCalendarFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        public new TraktCalendarFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        public new TraktCalendarFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        public new TraktCalendarFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        public new TraktCalendarFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        public override void Clear()
        {
            base.Clear();
            Query = null;
        }

        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasQuerySet)
                parameters.Add("query", Query);

            return parameters;
        }
    }
}
