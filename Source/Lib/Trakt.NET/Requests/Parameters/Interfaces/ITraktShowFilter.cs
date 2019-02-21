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

        ITraktShowFilter AddStates(TraktShowStatus status, params TraktShowStatus[] states);

        ITraktShowFilter WithStates(TraktShowStatus status, params TraktShowStatus[] states);

        ITraktShowFilter ClearStates();
    }
}
