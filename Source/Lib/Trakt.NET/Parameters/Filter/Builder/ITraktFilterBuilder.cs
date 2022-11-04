namespace TraktNet.Parameters
{
    using System.Collections.Generic;

    public interface ITraktFilterBuilder<TFilter, TFilterBuilder>
        where TFilter : ITraktFilter
        where TFilterBuilder : ITraktFilterBuilder<TFilter, TFilterBuilder>
    {
        TFilterBuilder WithQuery(string query);

        TFilterBuilder WithYear(uint year);

        TFilterBuilder WithYears(uint startYear, uint endYear);

        TFilterBuilder WithGenres(string genre, params string[] genres);

        TFilterBuilder WithGenres(IEnumerable<string> genres);

        TFilterBuilder WithLanguages(string language, params string[] languages);

        TFilterBuilder WithLanguages(IEnumerable<string> languages);

        TFilterBuilder WithCountries(string country, params string[] countries);

        TFilterBuilder WithCountries(IEnumerable<string> countries);

        TFilterBuilder WithRuntimes(uint start, uint end);

        TFilterBuilder WithStudios(string studio, params string[] studios);

        TFilterBuilder WithStudios(IEnumerable<string> studios);

        TFilter Build();
    }
}
