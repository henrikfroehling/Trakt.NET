namespace TraktNet.Requests.Parameters.Filter.Interfaces
{
    using Enums;

    public interface ITraktShowFilter<T> : ITraktShowAndMovieFilter<ITraktShowFilter<T>> where T : ITraktShowFilter<T>
    {
        string[] Networks { get; }

        TraktShowStatus[] States { get; }

        T AddNetworks(string network, params string[] networks);

        T WithNetworks(string network, params string[] networks);

        T ClearNetworks();

        T AddStates(TraktShowStatus status, params TraktShowStatus[] states);

        T WithStates(TraktShowStatus status, params TraktShowStatus[] states);

        T ClearStates();
    }
}
