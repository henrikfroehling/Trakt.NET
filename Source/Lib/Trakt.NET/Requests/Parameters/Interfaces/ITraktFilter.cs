namespace TraktNet.Requests.Parameters.Interfaces
{
    using System.Collections.Generic;
    using Utils;

    public interface ITraktFilter
    {
        string Query { get; }

        int? Year { get; }

        Range<int> Years { get; }

        string[] Genres { get; }

        string[] Languages { get; }

        string[] Countries { get; }

        Range<int> Runtimes { get; }

        Range<int> Ratings { get; }

        ITraktFilter WithQuery(string query);

        ITraktFilter ClearQuery();

        ITraktFilter WithYear(int year);

        ITraktFilter WithYears(int startYear, int EndYear);

        ITraktFilter ClearYears();

        ITraktFilter AddGenres(string genre, params string[] genres);

        ITraktFilter WithGenres(string genre, params string[] genres);

        ITraktFilter ClearGenres();

        ITraktFilter AddLanguages(string language, params string[] languages);

        ITraktFilter WithLanguages(string language, params string[] languages);

        ITraktFilter ClearLanguages();

        ITraktFilter AddCountries(string country, params string[] countries);

        ITraktFilter WithCountries(string country, params string[] countries);

        ITraktFilter ClearCountries();

        ITraktFilter WithRuntimes(int begin, int end);

        ITraktFilter ClearRuntimes();

        ITraktFilter WithRatings(int begin, int end);

        ITraktFilter ClearRatings();

        ITraktFilter Clear();

        IDictionary<string, object> GetParameters();

        string ToString();
    }
}
