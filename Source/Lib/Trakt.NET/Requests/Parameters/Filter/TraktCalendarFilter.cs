namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;

    public sealed class TraktCalendarFilter : TraktFilter<TraktCalendarFilter>, ITraktCalendarFilter
    {
        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.Clear()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.ClearYears()
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        ITraktCalendarFilter ITraktFilter<ITraktCalendarFilter>.WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
