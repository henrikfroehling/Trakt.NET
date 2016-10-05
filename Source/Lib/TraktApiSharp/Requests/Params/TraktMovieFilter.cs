namespace TraktApiSharp.Requests.Params
{
    using Utils;

    /// <summary>
    /// Provides additional filter parameters for some <see cref="Modules.TraktMoviesModule" /> methods.<para />
    /// Supported by <see cref="Modules.TraktMoviesModule.GetMostAnticipatedMoviesAsync(TraktExtendedInfo, TraktMovieFilter, int?, int?)" />,
    /// <see cref="Modules.TraktMoviesModule.GetMostCollectedMoviesAsync(Enums.TraktTimePeriod, TraktExtendedInfo, TraktMovieFilter, int?, int?)" />,
    /// <see cref="Modules.TraktMoviesModule.GetMostPlayedMoviesAsync(Enums.TraktTimePeriod, TraktExtendedInfo, TraktMovieFilter, int?, int?)" />,
    /// <see cref="Modules.TraktMoviesModule.GetMostWatchedMoviesAsync(Enums.TraktTimePeriod, TraktExtendedInfo, TraktMovieFilter, int?, int?)" />,
    /// <see cref="Modules.TraktMoviesModule.GetPopularMoviesAsync(TraktExtendedInfo, TraktMovieFilter, int?, int?)" />,
    /// <see cref="Modules.TraktMoviesModule.GetRecentlyUpdatedMoviesAsync(System.DateTime?, TraktExtendedInfo, int?, int?)" /> and
    /// <see cref="Modules.TraktMoviesModule.GetTrendingMoviesAsync(TraktExtendedInfo, TraktMovieFilter, int?, int?)" />.<para />
    /// This class has an fluent interface.
    /// <para>See <a href ="http://docs.trakt.apiary.io/#introduction/filters">"Trakt API Doc - Filters"</a> for more information.</para>
    /// </summary>
    public class TraktMovieFilter : TraktCommonMovieAndShowFilter
    {
        /// <summary>Initializes an empty <see cref="TraktMovieFilter" /> instance.</summary>
        public TraktMovieFilter() : base() { }

        /// <summary>Initializes an <see cref="TraktMovieFilter" /> instance with the given values.</summary>
        /// <param name="query">Query string for titles and descriptions.</param>
        /// <param name="years">Four digit year.</param>
        /// <param name="genres">An array of Trakt genre slugs.</param>
        /// <param name="languages">An array of two letter language codes.</param>
        /// <param name="countries">An array of two letter country codes.</param>
        /// <param name="runtimes">An <see cref="Range{T}" /> instance for minutes.</param>
        /// <param name="ratings">An <see cref="Range{T}" /> instance for ratings.</param>
        /// <param name="certifications">An array of content certificiations.</param>
        /// <exception cref="System.ArgumentException">Thrown, if the given query string is null or empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if the given <paramref name="years" /> value does not have four digits.
        /// Thrown, if the begin value of the given runtimes range is below zero or if its end value is below zero or
        /// if its end value is below its begin value.
        /// Thrown, if the begin value of the given ratings range is below zero or if its end value is below zero or
        /// if its end value is below its begin value or if its end value is above 100.
        /// Thrown, if the given language codes array contains a language code, which has more or less than two letters.
        /// Thrown, if the given country codes array contains a country code, which has more or less than two letters.
        /// </exception>
        public TraktMovieFilter(string query, int years, string[] genres = null, string[] languages = null,
                                string[] countries = null, Range<int>? runtimes = null, Range<int>? ratings = null,
                                string[] certifications = null)
            : base(query, years, genres, languages, countries, runtimes, ratings, certifications) { }

        /// <summary>Sets the query string parameter value.</summary>
        /// <param name="query">The query string for titles and descriptions.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentException">Thrown, if the given query string is null or empty.</exception>
        public new TraktMovieFilter WithQuery(string query)
        {
            base.WithQuery(query);
            return this;
        }

        /// <summary>Sets the years parameter value.</summary>
        /// <param name="years">A four digit year.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown, if the given years value does not have four digits.</exception>
        public new TraktMovieFilter WithYears(int years)
        {
            base.WithYears(years);
            return this;
        }

        /// <summary>Adds multiple Trakt genre slugs to the already existing Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        public new TraktMovieFilter AddGenres(string genre, params string[] genres)
        {
            base.AddGenres(genre, genres);
            return this;
        }

        /// <summary>Sets the Trakt genre slugs parameter and overwrites already existing ones with given Trakt genre slugs.</summary>
        /// <param name="genre">A Trakt genre slug.</param>
        /// <param name="genres">An optional array of Trakt genre slugs.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        public new TraktMovieFilter WithGenres(string genre, params string[] genres)
        {
            base.WithGenres(genre, genres);
            return this;
        }

        /// <summary>Adds multiple language codes to the already existing language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktMovieFilter AddLanguages(string language, params string[] languages)
        {
            base.AddLanguages(language, languages);
            return this;
        }

        /// <summary>Sets the language codes parameter and overwrites already existing ones with given language codes.</summary>
        /// <param name="language">A two letter language code.</param>
        /// <param name="languages">An optional array of two letter language codes.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if one the given language codes has more or less than two letters.
        /// </exception>
        public new TraktMovieFilter WithLanguages(string language, params string[] languages)
        {
            base.WithLanguages(language, languages);
            return this;
        }

        /// <summary>Adds multiple country codes to the already existing country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktMovieFilter AddCountries(string country, params string[] countries)
        {
            base.AddCountries(country, countries);
            return this;
        }

        /// <summary>Sets the country codes parameter and overwrites already existing ones with given country codes.</summary>
        /// <param name="country">A two letter country code.</param>
        /// <param name="countries">An optional array of two letter country codes.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if one the given country codes has more or less than two letters.
        /// </exception>
        public new TraktMovieFilter WithCountries(string country, params string[] countries)
        {
            base.WithCountries(country, countries);
            return this;
        }

        /// <summary>Sets the runtimes value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of the runtimes range.</param>
        /// <param name="end">The end value of the runtimes range.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value.
        /// </exception>
        public new TraktMovieFilter WithRuntimes(int begin, int end)
        {
            base.WithRuntimes(begin, end);
            return this;
        }

        /// <summary>Sets the ratings value parameter and overwrites already exisiting values with the given ones.</summary>
        /// <param name="begin">The begin value of ratings range.</param>
        /// <param name="end">The end value of the ratings range.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown, if the given begin value is below zero or if the given end value is below zero or
        /// if the given end value is below the given begin value or if the given end value is above 100.
        /// </exception>
        public new TraktMovieFilter WithRatings(int begin, int end)
        {
            base.WithRatings(begin, end);
            return this;
        }

        /// <summary>Adds multiple content certifications to the already existing content certifications.</summary>
        /// <param name="certification">A content certification.</param>
        /// <param name="certifications">An optional array of content certifications.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        public new TraktMovieFilter AddCertifications(string certification, params string[] certifications)
        {
            base.AddCertifications(certification, certifications);
            return this;
        }

        /// <summary>Sets the content certifications parameter and overwrites already existing ones with given content certifications.</summary>
        /// <param name="certification">A content certification.</param>
        /// <param name="certifications">An optional array of content certifications.</param>
        /// <returns>The current <see cref="TraktMovieFilter" /> instance.</returns>
        public new TraktMovieFilter WithCertifications(string certification, params string[] certifications)
        {
            base.WithCertifications(certification, certifications);
            return this;
        }
    }
}
