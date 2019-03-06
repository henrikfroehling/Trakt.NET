namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;

    public sealed class TraktMovieFilter : TraktShowAndMovieFilter<TraktMovieFilter>, ITraktMovieFilter
    {
        ITraktMovieFilter ITraktShowAndMovieFilter<ITraktMovieFilter>.AddCertifications(string certification, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.Clear()
        {
            throw new System.NotImplementedException();
        }

        ITraktMovieFilter ITraktShowAndMovieFilter<ITraktMovieFilter>.ClearCertifications()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.ClearYears()
        {
            throw new System.NotImplementedException();
        }

        ITraktMovieFilter ITraktShowAndMovieFilter<ITraktMovieFilter>.WithCertifications(string certificatio, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktMovieFilter> ITraktFilter<ITraktShowAndMovieFilter<ITraktMovieFilter>>.WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
