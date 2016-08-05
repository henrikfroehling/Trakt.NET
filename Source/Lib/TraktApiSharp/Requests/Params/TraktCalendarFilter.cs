namespace TraktApiSharp.Requests.Params
{
    using System;
    using System.Collections.Generic;
    using Utils;

    /// <summary>
    /// Provides additional filter parameters for all <see cref="Modules.TraktCalendarModule" /> methods.<para />
    /// This class has an fluent interface.
    /// <para>See <a href ="http://docs.trakt.apiary.io/#introduction/filters">"Trakt API Doc - Filters"</a> for more information.</para>
    /// </summary>
    public class TraktCalendarFilter : TraktCommonFilter
    {
        /// <summary>Initializes an empty <see cref="TraktCalendarFilter" /> instance.</summary>
        public TraktCalendarFilter() : base() { }

        /// <summary>Initializes an <see cref="TraktCalendarFilter" /> instance with the given values.</summary>
        /// <param name="query">Query string for titles and descriptions.</param>
        /// <param name="years">Four digit year.</param>
        /// <param name="genres">An array of Trakt genre slugs.</param>
        /// <param name="languages">An array of two letter language codes.</param>
        /// <param name="countries">An array of two letter country codes.</param>
        /// <param name="runtimes">An <see cref="Range{T}" /> instance for minutes.</param>
        /// <param name="ratings">An <see cref="Range{T}" /> instance for ratings.</param>
        /// <exception cref="ArgumentException">Thrown, if the given query string is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given <paramref name="years" /> value does not have four digits.
        /// Thrown, if the begin value of the given runtimes range is below zero or if its end value is below zero or
        /// if its end value is below its begin value.
        /// Thrown, if the begin value of the given ratings range is below zero or if its end value is below zero or
        /// if its end value is below its begin value or if its end value is above 100.
        /// Thrown, if the given language codes array contains a language code, which has more or less than two letters.
        /// Thrown, if the given country codes array contains a country code, which has more or less than two letters.
        /// </exception>
        public TraktCalendarFilter(string query, int years, string[] genres = null, string[] languages = null,
                                   string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null)
            : base(years, genres, languages, countries, runtimes, ratings)
        {
            WithQuery(query);
        }

        /// <summary>Returns the query string parameter value.</summary>
        public string Query { get; protected set; }

        /// <summary>Returns, whether the query string parameter is set.</summary>
        public bool HasQuerySet => !string.IsNullOrEmpty(Query);

        /// <summary>Returns, whether any parameters are set.</summary>
        public override bool HasValues => base.HasValues || HasQuerySet;

        /// <summary>Sets the query string parameter value.</summary>
        /// <param name="query">The query string for titles and descriptions.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given query string is null or empty.</exception>
        public TraktCalendarFilter WithQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("query not valid", nameof(query));

            Query = query;
            return this;
        }

        /// <summary>Sets the years parameter value.</summary>
        /// <param name="years">A four digit year.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given years value does not have four digits.</exception>
        public new TraktCalendarFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        /// <summary>Adds multiple Trakt genre slugs to the already existing Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        public new TraktCalendarFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        /// <summary>Sets the Trakt genre slugs parameter and overwrites already existing ones with given Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        public new TraktCalendarFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        /// <summary>Adds multiple language codes to the already existing language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktCalendarFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        /// <summary>Sets the language codes parameter and overwrites already existing ones with given language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktCalendarFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        /// <summary>Adds multiple country codes to the already existing country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktCalendarFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        /// <summary>Sets the country codes parameter and overwrites already existing ones with given country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktCalendarFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        /// <summary>Sets the runtimes value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of the runtimes range.</param>
        /// <param name="end">The end value of the runtimes range.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value.
        /// </exception>
        public new TraktCalendarFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        /// <summary>Sets the ratings value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of ratings range.</param>
        /// <param name="end">The end value of the ratings range.</param>
        /// <returns>The current <see cref="TraktCalendarFilter" /> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value or if the given end value is above 100.
        /// </exception>
        public new TraktCalendarFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        /// <summary>Deletes all filter parameter values.</summary>
        public override void Clear()
        {
            base.Clear();
            Query = null;
        }

        /// <summary>
        /// Creates a key-value-pair list of all set parameter-values.
        /// Each key-value-pair consists of the parameter name as key and its value.
        /// </summary>
        /// <returns>A key-value-pair list of all set parameter-values.</returns>
        public override IDictionary<string, object> GetParameters()
        {
            var parameters = base.GetParameters();

            if (HasQuerySet)
                parameters.Add("query", Query);

            return parameters;
        }
    }
}
