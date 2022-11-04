namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Utils;

    internal abstract class AFilterBuilder<TFilter, TFilterBuilder> : ITraktFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        protected string _query;
        protected uint? _year;
        protected Range<uint>? _years;
        protected Lazy<List<string>> _genres;
        protected Lazy<List<string>> _languages;
        protected Lazy<List<string>> _countries;
        protected Range<uint>? _runtimes;
        protected Lazy<List<string>> _studios;

        protected AFilterBuilder()
        {
            _query = null;
            _year = null;
            _years = null;
            _genres = new Lazy<List<string>>();
            _languages = new Lazy<List<string>>();
            _countries = new Lazy<List<string>>();
            _runtimes = null;
            _studios = new Lazy<List<string>>();
        }

        public TFilterBuilder WithQuery(string query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            if (query.Length == 0)
                throw new ArgumentException("query must not be empty", nameof(query));

            _query = query;
            return GetBuilder();
        }

        public TFilterBuilder WithYear(uint year)
        {
            if (year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(year), "year must be a 4 digit value");

            _year = year;
            _years = null;
            return GetBuilder();
        }

        public TFilterBuilder WithYears(uint startYear, uint endYear)
        {
            if (startYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(startYear), "year must be a 4 digit value");

            if (endYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(endYear), "year must be a 4 digit value");

            if (endYear < startYear)
                throw new ArgumentOutOfRangeException(nameof(startYear), "start year should be less than end year");

            _year = null;
            _years = new Range<uint>(startYear, endYear);
            return GetBuilder();
        }

        public TFilterBuilder WithGenres(string genre, params string[] genres)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));

            if (genre.Length > 0)
                _genres.Value.Add(genre);

            if (genres?.Length > 0)
            {
                foreach (string value in genres)
                {
                    if (!string.IsNullOrEmpty(value))
                        _genres.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public TFilterBuilder WithGenres(IEnumerable<string> genres)
        {
            if (genres == null)
                throw new ArgumentNullException(nameof(genres));

            foreach (string genre in genres)
            {
                if (!string.IsNullOrEmpty(genre))
                    _genres.Value.Add(genre);
            }

            return GetBuilder();
        }

        public TFilterBuilder WithLanguages(string language, params string[] languages)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            if (language.Length > 0)
                _languages.Value.Add(language);

            if (languages?.Length > 0)
            {
                foreach (string value in languages)
                {
                    if (!string.IsNullOrEmpty(value))
                        _languages.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public TFilterBuilder WithLanguages(IEnumerable<string> languages)
        {
            if (languages == null)
                throw new ArgumentNullException(nameof(languages));

            foreach (string language in languages)
            {
                if (!string.IsNullOrEmpty(language))
                    _languages.Value.Add(language);
            }

            return GetBuilder();
        }

        public TFilterBuilder WithCountries(string country, params string[] countries)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));

            if (country.Length > 0)
                _countries.Value.Add(country);

            if (countries?.Length > 0)
            {
                foreach (string value in countries)
                {
                    if (!string.IsNullOrEmpty(value))
                        _countries.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public TFilterBuilder WithCountries(IEnumerable<string> countries)
        {
            if (countries == null)
                throw new ArgumentNullException(nameof(countries));

            foreach (string country in countries)
            {
                if (!string.IsNullOrEmpty(country))
                    _countries.Value.Add(country);
            }

            return GetBuilder();
        }

        public TFilterBuilder WithRuntimes(uint start, uint end)
        {
            if (end < start)
                throw new ArgumentOutOfRangeException(nameof(start), "start should be less than end");

            _runtimes = new Range<uint>(start, end);
            return GetBuilder();
        }

        public TFilterBuilder WithStudios(string studio, params string[] studios)
        {
            if (studio == null)
                throw new ArgumentNullException(nameof(studio));

            if (studio.Length > 0)
                _studios.Value.Add(studio);

            if (studios?.Length > 0)
            {
                foreach (string value in studios)
                {
                    if (!string.IsNullOrEmpty(value))
                        _studios.Value.Add(value);
                }
            }

            return GetBuilder();
        }

        public TFilterBuilder WithStudios(IEnumerable<string> studios)
        {
            if (studios == null)
                throw new ArgumentNullException(nameof(studios));

            foreach (string studio in studios)
            {
                if (!string.IsNullOrEmpty(studio))
                    _studios.Value.Add(studio);
            }

            return GetBuilder();
        }

        public abstract TFilter Build();
        
        protected abstract TFilterBuilder GetBuilder();
    }
}
