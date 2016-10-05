namespace TraktApiSharp.Requests.Params
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public abstract class TraktCommonFilter
    {
        protected TraktCommonFilter() { }

        protected TraktCommonFilter(int years, string[] genres = null, string[] languages = null,
                                    string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null)
        {
            WithYears(years);
            WithGenres(null, genres);
            WithLanguages(null, languages);
            WithCountries(null, countries);
            Runtimes = runtimes;
            Ratings = ratings;
        }

        /// <summary>Returns the years parameter value.</summary>
        public int Years { get; protected set; }

        /// <summary>Returns, whether the years parameter is set.</summary>
        public bool HasYearsSet => Years > 0 && Years.ToString().Length == 4;

        /// <summary>Returns the Trakt genre slugs parameter value.</summary>
        public string[] Genres { get; protected set; }

        /// <summary>Returns, whether the Trakt genre slugs parameter is set.</summary>
        public bool HasGenresSet => Genres != null && Genres.Length > 0;

        /// <summary>Returns the language codes parameter value.</summary>
        public string[] Languages { get; protected set; }

        /// <summary>Returns, whether the language codes parameter is set.</summary>
        public bool HasLanguagesSet => Languages != null && Languages.Length > 0;

        /// <summary>Returns the country codes parameter value.</summary>
        public string[] Countries { get; protected set; }

        /// <summary>Returns, whether the country codes parameter is set.</summary>
        public bool HasCountriesSet => Countries != null && Countries.Length > 0;

        /// <summary>
        /// Returns the runtimes range parameter value.
        /// <para>See also <seealso cref="Range{T}" />.</para>
        /// </summary>
        public Range<int>? Runtimes { get; protected set; }

        /// <summary>Returns, whether the runtimes range parameter is set.</summary>
        public bool HasRuntimesSet()
        {
            if (Runtimes.HasValue)
            {
                var runtimes = Runtimes.Value;
                return runtimes.Begin > 0 && runtimes.End > 0 && runtimes.End > runtimes.Begin; ;
            }

            return false;
        }

        /// <summary>
        /// Returns the ratings range parameter value.
        /// <para>See also <seealso cref="Range{T}" />.</para>
        /// </summary>
        public Range<int>? Ratings { get; protected set; }

        /// <summary>Returns, whether the ratings range parameter is set.</summary>
        public bool HasRatingsSet()
        {
            if (Ratings.HasValue)
            {
                var ratings = Ratings.Value;
                return ratings.Begin > 0 && ratings.End > 0 && ratings.End > ratings.Begin && ratings.End <= 100;
            }

            return false;
        }

        public virtual bool HasValues => HasYearsSet || HasGenresSet || HasLanguagesSet || HasCountriesSet || HasRuntimesSet() || HasRatingsSet();

        public TraktCommonFilter WithYears(int years)
        {
            if (years < 0 || years.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(years), "years not valid");

            Years = years;
            return this;
        }

        public TraktCommonFilter AddGenres(string genre, params string[] genres) => AddGenres(true, genre, genres);

        public TraktCommonFilter WithGenres(string genre, params string[] genres) => AddGenres(false, genre, genres);

        public TraktCommonFilter AddLanguages(string language, params string[] languages) => AddLanguages(true, language, languages);

        public TraktCommonFilter WithLanguages(string language, params string[] languages) => AddLanguages(false, language, languages);

        public TraktCommonFilter AddCountries(string country, params string[] countries) => AddCountries(true, country, countries);

        public TraktCommonFilter WithCountries(string country, params string[] countries) => AddCountries(false, country, countries);

        public TraktCommonFilter WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentOutOfRangeException("runtimes not valid");

            Runtimes = new Range<int>(begin, end);
            return this;
        }

        public TraktCommonFilter WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentOutOfRangeException("ratings not valid");

            Ratings = new Range<int>(begin, end);
            return this;
        }

        /// <summary>Deletes all filter parameter values.</summary>
        public virtual void Clear()
        {
            Years = 0;
            Genres = null;
            Languages = null;
            Countries = null;
            Runtimes = null;
            Ratings = null;
        }

        /// <summary>
        /// Creates a key-value-pair list of all set parameter-values.
        /// Each key-value-pair consists of the parameter name as key and its value.
        /// </summary>
        /// <returns>A key-value-pair list of all set parameter-values.</returns>
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

            if (HasRuntimesSet())
            {
                var runtimes = Runtimes.Value;
                parameters.Add("runtimes", $"{runtimes.Begin.ToString()}-{runtimes.End.ToString()}");
            }

            if (HasRatingsSet())
            {
                var ratings = Ratings.Value;
                parameters.Add("ratings", $"{ratings.Begin.ToString()}-{ratings.End.ToString()}");
            }

            return parameters;
        }

        /// <summary>
        /// Creates a string containing all set parameters in form of "parameter-name=its-value" separated by an ampersand.
        /// </summary>
        /// <returns>A string containing all set parameters in form of "parameter-name=its-value" separated by an ampersand.</returns>
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

            this.Countries = countriesList.ToArray();

            return this;
        }
    }
}
