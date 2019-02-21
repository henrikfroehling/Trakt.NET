namespace TraktNet.Requests.Parameters.Interfaces
{
    using Enums;

    public interface ITraktShowFilter : ITraktShowAndMovieFilter
    {
        string[] Networks { get; }

        TraktShowStatus[] States { get; }

        ITraktShowFilter AddNetworks(string network, params string[] networks);

        ITraktShowFilter WithNetworks(string network, params string[] networks);

        ITraktShowFilter ClearNetworks();
    }
}
