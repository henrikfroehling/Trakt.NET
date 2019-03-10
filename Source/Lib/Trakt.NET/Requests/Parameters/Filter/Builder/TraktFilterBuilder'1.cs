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
                throw new ArgumentOutOfRangeException("runtimes not valid", default(Exception));

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
                throw new ArgumentOutOfRangeException("ratings not valid", default(Exception));

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
            var languagesList = new List<string>();

            if (CheckLanguage(language))
                languagesList.Add(language);

            if (CheckLanguages(languages))
                languagesList.AddRange(languages);

            if (keepExisting)
            {
                if (_filter.Languages != null && _filter.Languages.Length > 0)
                    languagesList.InsertRange(0, _filter.Languages);

                _filter.Languages = languagesList.ToArray();
            }
            else
                _filter.Languages = languagesList.ToArray();
        }

        private bool CheckLanguage(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                if (language.Length > 2 || language.Length < 2)
                    throw new ArgumentOutOfRangeException(nameof(language), "language not valid");

                return true;
            }

            return false;
        }

        private bool CheckLanguages(string[] languages)
        {
            if (languages != null && languages.Length > 0)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    if (languages[i].Length > 2 || languages[i].Length < 2)
                        throw new ArgumentOutOfRangeException(nameof(languages), "language item not valid");
                }

                return true;
            }

            return false;
        }

        private void AddCountries(bool keepExisting, string country, params string[] countries)
        {
            var countriesList = new List<string>();

            if (CheckCountry(country))
                countriesList.Add(country);

            if (CheckCountries(countries))
                countriesList.AddRange(countries);

            if (keepExisting)
            {
                if (_filter.Countries != null && _filter.Countries.Length > 0)
                    countriesList.InsertRange(0, _filter.Countries);

                _filter.Countries = countriesList.ToArray();
            }
            else
                _filter.Countries = countriesList.ToArray();
        }

        private bool CheckCountry(string country)
        {
            if (!string.IsNullOrEmpty(country))
            {
                if (country.Length > 2 || country.Length < 2)
                    throw new ArgumentOutOfRangeException(nameof(country), "country not valid");

                return true;
            }

            return false;
        }

        private bool CheckCountries(string[] countries)
        {
            if (countries != null && countries.Length > 0)
            {
                for (int i = 0; i < countries.Length; i++)
                {
                    if (countries[i].Length > 2 || countries[i].Length < 2)
                        throw new ArgumentOutOfRangeException(nameof(countries), "country item not valid");
                }

                return true;
            }

            return false;
        }
    }
}
