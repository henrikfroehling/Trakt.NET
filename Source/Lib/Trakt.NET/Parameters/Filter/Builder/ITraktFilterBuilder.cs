namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;

    public interface ITraktFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        /// <summary>Adds the given <paramref name="query"/> to the builder.</summary>
        /// <param name="query">A query which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="query"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="query"/> is empty.</exception>
        TFilterBuilder WithQuery(string query);

        /// <summary>
        /// Adds the given <paramref name="year"/> to the builder.
        /// <para>The method overwrites an already set years range.</para>
        /// </summary>
        /// <param name="year">A single 4 digit year which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="year"/> is not a 4 digit value.</exception>
        TFilterBuilder WithYear(uint year);

        /// <summary>
        /// Adds the given range of years, with <paramref name="startYear"/> and <paramref name="endYear"/>, to the builder.
        /// <para>The method overwrites an already set year.</para>
        /// </summary>
        /// <param name="startYear">The start value of the range of years. Should be a 4 digit value.</param>
        /// <param name="endYear">The end value of the range of years. Should be a 4 digit value.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="startYear"/> is not a 4 digit value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="endYear"/> is not a 4 digit value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="startYear"/> value is greater than the given <paramref name="endYear"/> value.</exception>
        TFilterBuilder WithYears(uint startYear, uint endYear);

        /// <summary>
        /// Adds the given <paramref name="genre"/> and optional list of <paramref name="genres"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="genre">A genre slug which will be added to the builder.</param>
        /// <param name="genres">An optional list of genre slugs which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="genre"/> is null.</exception>
        TFilterBuilder WithGenres(string genre, params string[] genres);

        /// <summary>
        /// Adds the given <paramref name="genres"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="genres">A list of genre slugs which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="genres"/> is null.</exception>
        TFilterBuilder WithGenres(IEnumerable<string> genres);

        /// <summary>Adds the given <paramref name="language"/> and optional list of <paramref name="languages"/> to the builder.</summary>
        /// <param name="language">A 2 character language code which will be added to the builder.</param>
        /// <param name="languages">An optional list of 2 character language codes which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="language"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="language"/> is not a 2 character language code.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if any of the given <paramref name="languages"/> is not a 2 character language code.</exception>
        TFilterBuilder WithLanguages(string language, params string[] languages);

        /// <summary>Adds the given <paramref name="languages"/> to the builder.</summary>
        /// <param name="languages">A list of 2 character language codes which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="languages"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if any of the given <paramref name="languages"/> is not a 2 character language code.</exception>
        TFilterBuilder WithLanguages(IEnumerable<string> languages);

        /// <summary>Adds the given <paramref name="country"/> and optional list of <paramref name="countries"/> to the builder.</summary>
        /// <param name="country">A 2 character country code which will be added to the builder.</param>
        /// <param name="countries">An optional list of 2 character country codes which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="country"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="country"/> is not a 2 character country code.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if any of the given <paramref name="countries"/> is not a 2 character country code.</exception>
        TFilterBuilder WithCountries(string country, params string[] countries);

        /// <summary>Adds the given <paramref name="countries"/> to the builder.</summary>
        /// <param name="countries">A list of 2 character country codes which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="countries"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if any of the given <paramref name="countries"/> is not a 2 character country code.</exception>
        TFilterBuilder WithCountries(IEnumerable<string> countries);

        /// <summary>Adds the given runtime range in minutes, with <paramref name="start"/> and <paramref name="end"/>, to the builder.</summary>
        /// <param name="start">The start value of the runtime range in minutes.</param>
        /// <param name="end">The end value of the runtime range in minutes.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown, if the given <paramref name="start"/> value is greater than the given <paramref name="end"/> value.</exception>
        TFilterBuilder WithRuntimes(uint start, uint end);

        /// <summary>
        /// Adds the given <paramref name="studio"/> and optional list of <paramref name="studios"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="studio">A studio slug which will be added to the builder.</param>
        /// <param name="studios">An optional list of studio slugs which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="studio"/> is null.</exception>
        TFilterBuilder WithStudios(string studio, params string[] studios);

        /// <summary>
        /// Adds the given <paramref name="studios"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="studios">An optional list of studio slugs which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <typeparamref name="TFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="studios"/> is null.</exception>
        TFilterBuilder WithStudios(IEnumerable<string> studios);

        /// <summary>Creates a new <typeparamref name="TFilter"/> instance.</summary>
        /// <returns>A new <typeparamref name="TFilter"/> instance.</returns>
        TFilter Build();
    }
}
