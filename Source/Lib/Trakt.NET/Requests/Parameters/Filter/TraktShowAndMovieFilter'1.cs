namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;

    public abstract class TraktShowAndMovieFilter<T> : TraktFilter<TraktShowAndMovieFilter<T>>, ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> where T : TraktShowAndMovieFilter<T>
    {
        public string[] Certifications => throw new System.NotImplementedException();

        public TraktShowAndMovieFilter<T> AddCertifications(string certification, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        public TraktShowAndMovieFilter<T> ClearCertifications()
        {
            throw new System.NotImplementedException();
        }

        public TraktShowAndMovieFilter<T> WithCertifications(string certificatio, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.Clear()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.ClearYears()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>> ITraktFilter<ITraktShowAndMovieFilter<TraktShowAndMovieFilter<T>>>.WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
