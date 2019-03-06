namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;

    public abstract class TraktFilter<T> : TraktFilter, ITraktFilter<TraktFilter<T>> where T : TraktFilter<T>
    {
        public TraktFilter<T> AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> Clear()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> ClearYears()
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public TraktFilter<T> WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
