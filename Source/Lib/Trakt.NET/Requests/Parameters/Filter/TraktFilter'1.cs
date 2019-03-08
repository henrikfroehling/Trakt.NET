namespace TraktNet.Requests.Parameters.Filter
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public abstract class TraktFilter<T> : TraktFilter where T : TraktFilter<T>
    {
        public T WithQuery(string query)
        {
            if (query != null && query == string.Empty)
                throw new ArgumentException("query not valid", nameof(query));

            Query = query;
            return (T)this;
        }

        public T ClearQuery()
        {
            Query = null;
            return (T)this;
        }

        public T WithYear(int year)
        {
            if (year < 0 || year.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(year), "year not valid");

            Years = null;
            Year = year;
            return (T)this;
        }

        public T WithYears(int startYear, int endYear)
        {
            if (startYear < 0 || startYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(startYear), "year not valid");

            if (endYear < 0 || endYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(endYear), "year not valid");

            Year = null;
            Years = new Range<int>(startYear, endYear);
            return (T)this;
        }

        public T ClearYears()
        {
            Year = null;
            Years = null;
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
            Genres = null;
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
            Languages = null;
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
            Countries = null;
            return (T)this;
        }

        public T WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentOutOfRangeException("runtimes not valid");

            Runtimes = new Range<int>(begin, end);
            return (T)this;
        }

        public T ClearRuntimes()
        {
            Runtimes = null;
            return (T)this;
        }

        public T WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentOutOfRangeException("ratings not valid");

            Ratings = new Range<int>(begin, end);
            return (T)this;
        }

        public T ClearRatings()
        {
            Ratings = null;
            return (T)this;
        }

        public T Clear()
        {
            ClearAll();
            return (T)this;
        }

        public override string ToString()
        {
            var parameters = GetParameters();

            if (parameters.Count <= 0)
                return string.Empty;

            var keyValues = new List<string>();

            foreach (var param in parameters)
                keyValues.Add($"{param.Key}={param.Value}");

            return string.Join("&", keyValues);
        }

        protected bool HasQuerySet => !string.IsNullOrEmpty(Query);

        protected bool HasYearSet => Year.HasValue && Year.Value.ToString().Length == 4;

        protected bool HasYearsSet()
        {
            if (Years.HasValue)
            {
                Range<int> years = Years.Value;
                int startYear = years.Begin;
                int endYear = years.End;
                return startYear <= endYear && startYear.ToString().Length == 4 && endYear.ToString().Length == 4;
            }

            return false;
        }

        protected bool HasGenresSet => Genres != null && Genres.Length > 0;

        protected bool HasLanguagesSet => Languages != null && Languages.Length > 0;

        protected bool HasCountriesSet => Countries != null && Countries.Length > 0;

        protected bool HasRuntimesSet()
        {
            if (Runtimes.HasValue)
            {
                Range<int> runtimes = Runtimes.Value;
                return runtimes.Begin > 0 && runtimes.End > 0 && runtimes.End > runtimes.Begin;
            }

            return false;
        }

        protected bool HasRatingsSet()
        {
            if (Ratings.HasValue)
            {
                Range<int> ratings = Ratings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin && ratings.End <= 100;
            }

            return false;
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

        internal virtual bool HasValues => HasQuerySet || HasYearSet || HasYearsSet() || HasGenresSet || HasLanguagesSet || HasCountriesSet || HasRuntimesSet() || HasRatingsSet();

        internal virtual IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasQuerySet)
                parameters.Add("query", Query);

            if (HasYearSet && !HasYearsSet())
                parameters.Add("years", $"{Year.Value}");
            else if (!HasYearSet && HasYearsSet())
            {
                int startYear = Years.Value.Begin;
                int endYear = Years.Value.End;

                if (startYear <= endYear)
                    parameters.Add("years", $"{startYear}-{endYear}");
                else
                    parameters.Add("years", $"{endYear}-{startYear}");
            }

            if (HasGenresSet)
                parameters.Add("genres", string.Join(",", Genres));

            if (HasLanguagesSet)
                parameters.Add("languages", string.Join(",", Languages));

            if (HasCountriesSet)
                parameters.Add("countries", string.Join(",", Countries));

            if (HasRuntimesSet())
            {
                var runtimes = Runtimes.Value;
                parameters.Add("runtimes", $"{runtimes.Begin}-{runtimes.End}");
            }

            if (HasRatingsSet())
            {
                var ratings = Ratings.Value;
                parameters.Add("ratings", $"{ratings.Begin}-{ratings.End}");
            }

            return parameters;
        }

        private void AddGenres(bool keepExisting, string genre, params string[] genres)
        {
            if (string.IsNullOrEmpty(genre) && (genres == null || genres.Length <= 0))
            {
                if (!keepExisting)
                    Genres = null;

                return;
            }

            var genresList = new List<string>();

            if (keepExisting && Genres != null && Genres.Length > 0)
                genresList.AddRange(Genres);

            if (!string.IsNullOrEmpty(genre))
                genresList.Add(genre);

            if (genres != null && genres.Length > 0)
                genresList.AddRange(genres);

            Genres = genresList.ToArray();
        }

        private void AddLanguages(bool keepExisting, string language, params string[] languages)
        {
            if (string.IsNullOrEmpty(language) && (languages == null || languages.Length <= 0))
            {
                if (!keepExisting)
                    Languages = null;

                return;
            }

            var languagesList = new List<string>();

            if (keepExisting && Languages != null && Languages.Length > 0)
                languagesList.AddRange(Languages);

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

            Languages = languagesList.ToArray();
        }

        private void AddCountries(bool keepExisting, string country, params string[] countries)
        {
            if (string.IsNullOrEmpty(country) && (countries == null || countries.Length <= 0))
            {
                if (!keepExisting)
                    Countries = null;

                return;
            }

            var countriesList = new List<string>();

            if (keepExisting && Countries != null && Countries.Length > 0)
                countriesList.AddRange(Countries);

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

            Countries = countriesList.ToArray();
        }
    }
}
