namespace TraktNet.Requests.Parameters.Filter
{
    public abstract class TraktFilter<T> : TraktFilter where T : TraktFilter<T>
    {
        public T WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public T ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        public T WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public T WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }

        public T ClearYears()
        {
            throw new System.NotImplementedException();
        }

        public T AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        public T WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        public T ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        public T AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        public T WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        public T ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        public T AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        public T WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        public T ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        public T WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        public T ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        public T WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        public T ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        public T Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
