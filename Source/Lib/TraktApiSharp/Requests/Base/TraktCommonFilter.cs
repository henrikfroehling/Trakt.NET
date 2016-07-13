namespace TraktApiSharp.Requests.Base
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public abstract class TraktCommonFilter
    {
        protected TraktCommonFilter() { }

        protected TraktCommonFilter(int years, string[] genres = null, string[] languages = null,
                                    string[] countries = null, Range<int> runtimes = null, Range<int> ratings = null)
        {
            WithYears(years);
            WithGenres(null, genres);
            WithLanguages(null, languages);
            WithCountries(null, countries);
            WithRuntimes(runtimes.Begin, runtimes.End);
            WithRatings(ratings.Begin, ratings.End);
        }

        public int Years { get; protected set; }

        public bool HasYearsSet => Years > 0 && Years.ToString().Length == 4;

        public string[] Genres { get; protected set; }

        public bool HasGenresSet => Genres != null && Genres.Length > 0;

        public string[] Languages { get; protected set; }

        public bool HasLanguagesSet => Languages != null && Languages.Length > 0;

        public string[] Countries { get; protected set; }

        public bool HasCountriesSet => Countries != null && Countries.Length > 0;

        public Range<int> Runtimes { get; protected set; }

        public bool HasRuntimesSet => Runtimes != null && Runtimes.Begin > 0 && Runtimes.End > 0 && Runtimes.End > Runtimes.Begin;

        public Range<int> Ratings { get; protected set; }

        public bool HasRatingsSet => Ratings != null && Ratings.Begin > 0 && Ratings.End > 0 && Ratings.End > Ratings.Begin && Ratings.End <= 100;

        public virtual bool HasValues => HasYearsSet || HasGenresSet || HasLanguagesSet || HasCountriesSet || HasRuntimesSet || HasRatingsSet;

        public TraktCommonFilter WithYears(int years)
        {
            var length = years.ToString().Length;

            if (years < 0 || length > 4 || length < 4)
                throw new ArgumentException("years not valid", nameof(years));

            Years = years;
            return this;
        }

        public TraktCommonFilter AddGenres(string genre, params string[] genres)
        {
            return AddGenres(true, genre, genres);
        }

        public TraktCommonFilter WithGenres(string genre, params string[] genres)
        {
            return AddGenres(false, genre, genres);
        }

        public TraktCommonFilter AddLanguages(string language, params string[] languages)
        {
            return AddLanguages(true, language, languages);
        }

        public TraktCommonFilter WithLanguages(string language, params string[] languages)
        {
            return AddLanguages(false, language, languages);
        }

        public TraktCommonFilter AddCountries(string country, params string[] countries)
        {
            return AddCountries(true, country, countries);
        }

        public TraktCommonFilter WithCountries(string country, params string[] countries)
        {
            return AddCountries(false, country, countries);
        }

        public TraktCommonFilter WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentException("runtimes not valid");

            Runtimes = new Range<int>(begin, end);
            return this;
        }

        public TraktCommonFilter WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentException("ratings not valid");

            Ratings = new Range<int>(begin, end);
            return this;
        }

        public virtual void Clear()
        {
            Years = 0;
            Genres = null;
            Languages = null;
            Countries = null;
            Runtimes = null;
            Ratings = null;
        }

        public virtual IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasYearsSet)
                parameters.Add("years", Years.ToString());

            if (HasGenresSet)
                parameters.Add("genres", string.Join(",", Genres));

            if (HasLanguagesSet)
                parameters.Add("languages", string.Join(",", Languages));

            if (HasCountriesSet)
                parameters.Add("countries", string.Join(",", Countries));

            if (HasRuntimesSet)
                parameters.Add("runtimes", $"{Runtimes.Begin.ToString()}-{Runtimes.End.ToString()}");

            if (HasRatingsSet)
                parameters.Add("ratings", $"{Ratings.Begin.ToString()}-{Ratings.End.ToString()}");

            return parameters;
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

        private TraktCommonFilter AddGenres(bool keepExisting, string genre, params string[] genres)
        {
            var genresList = new List<string>();

            if (keepExisting && this.Genres != null && this.Genres.Length > 0)
                genresList.AddRange(this.Genres);

            if (!string.IsNullOrEmpty(genre))
                genresList.Add(genre);

            if (genres != null && genres.Length > 0)
                genresList.AddRange(genres);

            this.Genres = genresList.ToArray();

            return this;
        }

        private TraktCommonFilter AddLanguages(bool keepExisting, string language, params string[] languages)
        {
            var languagesList = new List<string>();

            if (keepExisting && this.Languages != null && this.Languages.Length > 0)
                languagesList.AddRange(this.Languages);

            if (!string.IsNullOrEmpty(language))
            {
                if (language.Length > 2 || language.Length < 2)
                    throw new ArgumentException("language not valid", nameof(language));

                languagesList.Add(language);
            }

            if (languages != null && languages.Length > 0)
            {
                for (int i = 0; i < languages.Length; i++)
                {
                    if (languages[i].Length > 2 || languages[i].Length < 2)
                        throw new ArgumentException("language not valid", nameof(languages));
                }

                languagesList.AddRange(languages);
            }

            this.Languages = languagesList.ToArray();

            return this;
        }

        private TraktCommonFilter AddCountries(bool keepExisting, string country, params string[] countries)
        {
            var countriesList = new List<string>();

            if (keepExisting && this.Countries != null && this.Countries.Length > 0)
                countriesList.AddRange(this.Countries);

            if (!string.IsNullOrEmpty(country))
            {
                if (country.Length > 2 || country.Length < 2)
                    throw new ArgumentException("country not valid", nameof(country));

                countriesList.Add(country);
            }

            if (countries != null && countries.Length > 0)
            {
                for (int i = 0; i < countries.Length; i++)
                {
                    if (countries[i].Length > 2 || countries[i].Length < 2)
                        throw new ArgumentException("country not valid", nameof(countries));
                }

                countriesList.AddRange(countries);
            }

            this.Countries = countriesList.ToArray();

            return this;
        }
    }
}
