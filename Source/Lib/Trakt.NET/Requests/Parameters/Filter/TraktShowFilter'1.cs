namespace TraktNet.Requests.Parameters.Filter
{
    using Enums;
    using Interfaces;

    public class TraktShowFilter<T> : TraktShowAndMovieFilter<TraktShowFilter<T>>, ITraktShowFilter<TraktShowFilter<T>> where T : TraktShowFilter<T>
    {
        public string[] Networks => throw new System.NotImplementedException();

        public TraktShowStatus[] States => throw new System.NotImplementedException();

        public TraktShowFilter<T> AddNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        public TraktShowFilter<T> AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        public TraktShowFilter<T> ClearNetworks()
        {
            throw new System.NotImplementedException();
        }

        public TraktShowFilter<T> ClearStates()
        {
            throw new System.NotImplementedException();
        }

        public TraktShowFilter<T> WithNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        public TraktShowFilter<T> WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowFilter<TraktShowFilter<T>> ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>.AddCertifications(string certification, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.Clear()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowFilter<TraktShowFilter<T>> ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>.ClearCertifications()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.ClearYears()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowFilter<TraktShowFilter<T>> ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>.WithCertifications(string certificatio, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<TraktShowFilter<T>>>>.WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
