namespace TraktNet.Requests.Parameters.Filter.Builder
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public abstract class TraktFilterBuilder<T, U> where T : TraktFilterBuilder<T, U> where U : ATraktFilter
    {
        protected U _filter;

        protected TraktFilterBuilder(U filter)
        {
            _filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public U Build() => _filter;

        public T WithQuery(string query)
        {
            if (query != null && query == string.Empty)
                throw new ArgumentException("query not valid", nameof(query));

            _filter.Query = query;
            return (T)this;
        }

        public T ClearQuery()
        {
            _filter.Query = null;
            return (T)this;
        }

        public T WithYear(int year)
        {
            if (year < 0 || year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(year), "year not valid");

            _filter.Years = null;
            _filter.Year = year;
            return (T)this;
        }

        public T WithYears(int startYear, int endYear)
        {
            if (startYear < 0 || startYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(startYear), "year not valid");

            if (endYear < 0 || endYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(endYear), "year not valid");

            _filter.Year = null;
            _filter.Years = new Range<int>(startYear, endYear);
            return (T)this;
        }

        public T ClearYears()
        {
            _filter.Year = null;
            _filter.Years = null;
            return (T)this;
        }

        public T AddGenres(string genre, params string[] genres)
        {
            AddGenres(true, genre, genres);
            return (T)this;
        }

        public T WithGenres(string genre, params string[] genres)
        {
            AddGenres(false, genre, genres);
            return (T)this;
        }

        public T ClearGenres()
        {
            _filter.Genres = null;
            return (T)this;
        }

        public T AddLanguages(string language, params string[] languages)
        {
            AddLanguages(true, language, languages);
            return (T)this;
        }

        public T WithLanguages(string language, params string[] languages)
        {
            AddLanguages(false, language, languages);
            return (T)this;
        }

        public T ClearLanguages()
        {
            _filter.Languages = null;
            return (T)this;
        }

        public T AddCountries(string country, params string[] countries)
        {
            AddCountries(true, country, countries);
            return (T)this;
        }

        public T WithCountries(string country, params string[] countries)
        {
            AddCountries(false, country, countries);
            return (T)this;
        }

        public T ClearCountries()
        {
            _filter.Countries = null;
            return (T)this;
        }

        public T WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentOutOfRangeException("runtimes not valid");

            _filter.Runtimes = new Range<int>(begin, end);
            return (T)this;
        }

        public T ClearRuntimes()
        {
            _filter.Runtimes = null;
            return (T)this;
        }

        public T WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentOutOfRangeException("ratings not valid");

            _filter.Ratings = new Range<int>(begin, end);
            return (T)this;
        }

        public T ClearRatings()
        {
            _filter.Ratings = null;
            return (T)this;
        }

        public T Clear()
        {
            ClearAll();
            return (T)this;
        }

        protected virtual void ClearAll()
        {
            ClearQuery();
            ClearYears();
            ClearGenres();
            ClearLanguages();
            ClearCountries();
            ClearRuntimes();
            ClearRatings();
        }

        private void AddGenres(bool keepExisting, string genre, params string[] genres)
        {
            if (string.IsNullOrEmpty(genre) && (genres == null || genres.Length <= 0))
            {
                if (!keepExisting)
                    _filter.Genres = null;

                return;
            }

            var genresList = new List<string>();

            if (keepExisting && _filter.Genres != null && _filter.Genres.Length > 0)
                genresList.AddRange(_filter.Genres);

            if (!string.IsNullOrEmpty(genre))
                genresList.Add(genre);

            if (genres != null && genres.Length > 0)
                genresList.AddRange(genres);

            _filter.Genres = genresList.ToArray();
        }

        private void AddLanguages(bool keepExisting, string language, params string[] languages)
        {
            if (string.IsNullOrEmpty(language) && (languages == null || languages.Length <= 0))
            {
                if (!keepExisting)
                    _filter.Languages = null;

                return;
            }

            var languagesList = new List<string>();

            if (keepExisting && _filter.Languages != null && _filter.Languages.Length > 0)
                languagesList.AddRange(_filter.Languages);

            if (!string.IsNullOrEmpty(language))
            {
                if (language.Length > 2 || language.Length < 2)
                    throw new ArgumentOutOfRangeException("language not valid", nameof(language));

                languagesList.Add(language);
            }

            if (languages != null && languages.Length > 0)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    if (languages[i].Length > 2 || languages[i].Length < 2)
                        throw new ArgumentOutOfRangeException("language not valid", nameof(languages));
                }

                languagesList.AddRange(languages);
            }

            _filter.Languages = languagesList.ToArray();
        }

        private void AddCountries(bool keepExisting, string country, params string[] countries)
        {
            if (string.IsNullOrEmpty(country) && (countries == null || countries.Length <= 0))
            {
                if (!keepExisting)
                    _filter.Countries = null;

                return;
            }

            var countriesList = new List<string>();

            if (keepExisting && _filter.Countries != null && _filter.Countries.Length > 0)
                countriesList.AddRange(_filter.Countries);

            if (!string.IsNullOrEmpty(country))
            {
                if (country.Length > 2 || country.Length < 2)
                    throw new ArgumentOutOfRangeException("country not valid", nameof(country));

                countriesList.Add(country);
            }

            if (countries != null && countries.Length > 0)
            {
                for (int i = 0; i < countries.Length; i++)
                {
                    if (countries[i].Length > 2 || countries[i].Length < 2)
                        throw new ArgumentOutOfRangeException("country not valid", nameof(countries));
                }

                countriesList.AddRange(countries);
            }

            _filter.Countries = countriesList.ToArray();
        }
    }
}
