namespace TraktNet.Parameters
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Enums;

    /// <summary>
    /// Filter builder for <see cref="ITraktShowFilter" />s.
    /// <para>Provides methods for adding values to a <see cref="ITraktShowFilter"/>.</para>
    /// </summary>
    public interface ITraktShowFilterBuilder
        : ITraktShowAndMovieFilterBuilder<ITraktShowFilter, ITraktShowFilterBuilder>,
          ITraktShowRatingsFilterBuilder
    {
        /// <summary>
        /// Adds the given <paramref name="network"/> and optional list of <paramref name="networks"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="network">A network name which will be added to the builder.</param>
        /// <param name="networks">An optional list of network names which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="network"/> is null.</exception>
        ITraktShowFilterBuilder WithNetworks(string network, params string[] networks);

        /// <summary>
        /// Adds the given <paramref name="networks"/> to the builder.
        /// <para>Empty values will be ignored.</para>
        /// </summary>
        /// <param name="networks">A list of network names which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        ITraktShowFilterBuilder WithNetworks(IEnumerable<string> networks);

        /// <summary>Adds the given <paramref name="status"/> and optional list of <paramref name="states"/> to the builder.</summary>
        /// <param name="status">A <see cref="TraktShowStatus"/> which will be added to the builder.</param>
        /// <param name="states">An optional list of <see cref="TraktShowStatus"/> which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="status"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if the given <paramref name="status"/> has the value <see cref="TraktShowStatus.Unspecified"/>.</exception>
        /// <exception cref="ArgumentException">Thrown, if any of the given <paramref name="states"/> has the value <see cref="TraktShowStatus.Unspecified"/>.</exception>
        ITraktShowFilterBuilder WithStates(TraktShowStatus status, params TraktShowStatus[] states);

        /// <summary>Adds the given <paramref name="states"/> to the builder.</summary>
        /// <param name="states">A list of <see cref="TraktShowStatus"/> which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="states"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown, if any of the given <paramref name="states"/> has the value <see cref="TraktShowStatus.Unspecified"/>.</exception>
        ITraktShowFilterBuilder WithStates(IEnumerable<TraktShowStatus> states);
    }
}
