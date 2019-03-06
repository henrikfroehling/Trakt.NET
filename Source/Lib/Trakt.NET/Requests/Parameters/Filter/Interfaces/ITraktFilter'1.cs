namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    public interface ITraktFilter<T> : ITraktFilter where T : ITraktFilter<T>
    {
        T WithQuery(string query);

        T ClearQuery();

        T WithYear(int year);

        T WithYears(int startYear, int EndYear);

        T ClearYears();

        T AddGenres(string genre, params string[] genres);

        T WithGenres(string genre, params string[] genres);

        T ClearGenres();

        T AddLanguages(string language, params string[] languages);

        T WithLanguages(string language, params string[] languages);

        T ClearLanguages();

        T AddCountries(string country, params string[] countries);

        T WithCountries(string country, params string[] countries);

        T ClearCountries();

        T WithRuntimes(int begin, int end);

        T ClearRuntimes();

        T WithRatings(int begin, int end);

        T ClearRatings();

        T Clear();
    }
}
