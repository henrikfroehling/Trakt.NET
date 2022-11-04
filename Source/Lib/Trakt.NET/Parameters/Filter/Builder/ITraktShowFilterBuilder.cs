namespace TraktNet.Parameters
{
    using System.Collections.Generic;
    using TraktNet.Enums;

    public interface ITraktShowFilterBuilder
        : ITraktShowAndMovieFilterBuilder<ITraktShowFilter, ITraktShowFilterBuilder>,
          ITraktShowRatingsFilterBuilder
    {
        ITraktShowFilterBuilder WithNetworks(string network, params string[] networks);

        ITraktShowFilterBuilder WithNetworks(IEnumerable<string> networks);

        ITraktShowFilterBuilder WithStates(TraktShowStatus status, params TraktShowStatus[] states);

        ITraktShowFilterBuilder WithStates(IEnumerable<TraktShowStatus> states);
    }
}
