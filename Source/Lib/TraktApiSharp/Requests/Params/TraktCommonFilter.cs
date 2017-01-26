namespace TraktApiSharp.Requests.Params
{
    using System;
    using System.Collections.Generic;
    using Utils;

    public abstract class TraktCommonFilter
    {
        protected TraktCommonFilter(int? startYear = null, int? endYear = null, string[] genres = null, string[] languages = null,
                                    string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null)
        {
            if (startYear.HasValue)
                WithStartYear(startYear.Value);

            if (endYear.HasValue)
                WithEndYear(endYear.Value);

            WithGenres(null, genres);
            WithLanguages(null, languages);
            WithCountries(null, countries);

            if (runtimes.HasValue)
                WithRuntimes(runtimes.Value.Begin, runtimes.Value.End);

            if (ratings.HasValue)
                WithRatings(ratings.Value.Begin, ratings.Value.End);
        }

        /// <summary>Returns the start year of the years parameter value.</summary>
        public int? StartYear { get; protected set; }

        /// <summary>Returns the end year of the years parameter value.</summary>
        public int? EndYear { get; protected set; }

        /// <summary>Returns, whether the years parameter has set a start year.</summary>
        public bool HasStartYearSet => StartYear.HasValue && StartYear > 0 && StartYear.ToString().Length == 4;

        /// <summary>Returns, whether the years parameter has set an end year.</summary>
        public bool HasEndYearSet => EndYear.HasValue && EndYear > 0 && EndYear.ToString().Length == 4;

        /// <summary>Returns, whether the years parameter has set a start and / or end year.</summary>
        public bool HasYearsSet => HasStartYearSet || HasEndYearSet;

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
                return runtimes.Begin > 0 && runtimes.End > 0 && runtimes.End > runtimes.Begin;
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

        public TraktCommonFilter WithStartYear(int startYear)
        {
            if (startYear < 0 || startYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(startYear), "year not valid");

            StartYear = startYear;
            return this;
        }

        public TraktCommonFilter WithEndYear(int endYear)
        {
            if (endYear < 0 || endYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(endYear), "year not valid");

            EndYear = endYear;
            return this;
        }

        public TraktCommonFilter WithYears(int startYear, int endYear)
        {
            if (startYear < 0 || startYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(startYear), "year not valid");

            if (endYear < 0 || endYear.ToString().Length != 4)
                throw new ArgumentOutOfRangeException(nameof(endYear), "year not valid");

            StartYear = startYear;
            EndYear = endYear;
            return this;
        }

        public TraktCommonFilter ClearStartYear()
        {
            StartYear = null;
            return this;
        }

        public TraktCommonFilter ClearEndYear()
        {
            EndYear = null;
            return this;
        }

        public TraktCommonFilter ClearYears()
        {
            StartYear = null;
            EndYear = null;
            return this;
        }

        public TraktCommonFilter AddGenres(string genre, params string[] genres) => AddGenres(true, genre, genres);

        public TraktCommonFilter WithGenres(string genre, params string[] genres) => AddGenres(false, genre, genres);

        public TraktCommonFilter ClearGenres()
        {
            Genres = null;
            return this;
        }

        public TraktCommonFilter AddLanguages(string language, params string[] languages) => AddLanguages(true, language, languages);

        public TraktCommonFilter WithLanguages(string language, params string[] languages) => AddLanguages(false, language, languages);

        public TraktCommonFilter ClearLanguages()
        {
            Languages = null;
            return this;
        }

        public TraktCommonFilter AddCountries(string country, params string[] countries) => AddCountries(true, country, countries);

        public TraktCommonFilter WithCountries(string country, params string[] countries) => AddCountries(false, country, countries);

        public TraktCommonFilter ClearCountries()
        {
            Countries = null;
            return this;
        }

        public TraktCommonFilter WithRuntimes(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin)
                throw new ArgumentOutOfRangeException("runtimes not valid");

            Runtimes = new Range<int>(begin, end);
            return this;
        }

        public TraktCommonFilter ClearRuntimes()
        {
            Runtimes = null;
            return this;
        }

        public TraktCommonFilter WithRatings(int begin, int end)
        {
            if (begin < 0 || end < 0 || end < begin || end > 100)
                throw new ArgumentOutOfRangeException("ratings not valid");

            Ratings = new Range<int>(begin, end);
            return this;
        }

        public TraktCommonFilter ClearRatings()
        {
            Ratings = null;
            return this;
        }

        public TraktCommonFilter Clear()
        {
            StartYear = null;
            EndYear = null;
            Genres = null;
            Languages = null;
            Countries = null;
            Runtimes = null;
            Ratings = null;
            return this;
        }

        /// <summary>
        /// Creates a key-value-pair list of all set parameter-values.
        /// Each key-value-pair consists of the parameter name as key and its value.
        /// </summary>
        /// <returns>A key-value-pair list of all set parameter-values.</returns>
        public virtual IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (HasStartYearSet && !HasEndYearSet)
            {
                parameters.Add("years", $"{StartYear}");
            }
            else if (!HasStartYearSet && HasEndYearSet)
            {
                parameters.Add("years", $"{EndYear}");
            }
            else if (HasStartYearSet && HasEndYearSet)
            {
                if (StartYear <= EndYear)
                    parameters.Add("years", $"{StartYear}-{EndYear}");
                else
                    parameters.Add("years", $"{EndYear}-{StartYear}");
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
            if (string.IsNullOrEmpty(genre) && (genres == null || genres.Length <= 0))
            {
                if (!keepExisting)
                    Genres = null;

                return this;
            }

            var genresList = new List<string>();

            if (keepExisting && Genres != null && Genres.Length > 0)
                genresList.AddRange(Genres);

            if (!string.IsNullOrEmpty(genre))
                genresList.Add(genre);

            if (genres != null && genres.Length > 0)
                genresList.AddRange(genres);

            Genres = genresList.ToArray();

            return this;
        }

        private TraktCommonFilter AddLanguages(bool keepExisting, string language, params string[] languages)
        {
            if (string.IsNullOrEmpty(language) && (languages == null || languages.Length <= 0))
            {
                if (!keepExisting)
                    Languages = null;

                return this;
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

            return this;
        }

        private TraktCommonFilter AddCountries(bool keepExisting, string country, params string[] countries)
        {
            if (string.IsNullOrEmpty(country) && (countries == null || countries.Length <= 0))
            {
                if (!keepExisting)
                    Countries = null;

                return this;
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

            return this;
        }
    }
}
