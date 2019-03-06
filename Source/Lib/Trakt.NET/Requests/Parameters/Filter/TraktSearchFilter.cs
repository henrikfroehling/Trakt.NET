namespace TraktNet.Requests.Parameters.Filter
{
    using Interfaces;
    using TraktNet.Enums;

    public sealed class TraktSearchFilter : TraktShowFilter<TraktSearchFilter>, ITraktSearchFilter
    {
        ITraktShowFilter<ITraktSearchFilter> ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>.AddCertifications(string certification, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.AddCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.AddGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.AddLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.AddNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.AddStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.Clear()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowFilter<ITraktSearchFilter> ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>.ClearCertifications()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearCountries()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearGenres()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearLanguages()
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.ClearNetworks()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearQuery()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearRatings()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearRuntimes()
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.ClearStates()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.ClearYears()
        {
            throw new System.NotImplementedException();
        }

        ITraktShowFilter<ITraktSearchFilter> ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>.WithCertifications(string certificatio, params string[] certifications)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithCountries(string country, params string[] countries)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithGenres(string genre, params string[] genres)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithLanguages(string language, params string[] languages)
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.WithNetworks(string network, params string[] networks)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithRatings(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithRuntimes(int begin, int end)
        {
            throw new System.NotImplementedException();
        }

        ITraktSearchFilter ITraktShowFilter<ITraktSearchFilter>.WithStates(TraktShowStatus status, params TraktShowStatus[] states)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithYear(int year)
        {
            throw new System.NotImplementedException();
        }

        ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>> ITraktFilter<ITraktShowAndMovieFilter<ITraktShowFilter<ITraktSearchFilter>>>.WithYears(int startYear, int EndYear)
        {
            throw new System.NotImplementedException();
        }
    }
}
