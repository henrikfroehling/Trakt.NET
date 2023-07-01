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
        /// Adds the given <paramref name="networkId"/> and optional list of <paramref name="networkIds"/> to the builder.
        /// <para>Network ids == 0 will be ignored.</para>
        /// </summary>
        /// <param name="networkId">A network id which will be added to the builder.</param>
        /// <param name="networkIds">An optional list of network ids which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        ITraktShowFilterBuilder WithNetworkIds(uint networkId, params uint[] networkIds);

        /// <summary>
        /// Adds the given <paramref name="networkIds"/> to the builder.
        /// <para>Network ids == 0 will be ignored.</para>
        /// </summary>
        /// <param name="networkIds">A list of network ids which will be added to the builder.</param>
        /// <returns>Returns a reference to itself. See also <seealso cref="ITraktShowFilterBuilder"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown, if the given <paramref name="networkIds"/> is null.</exception>
        ITraktShowFilterBuilder WithNetworkIds(IEnumerable<uint> networkIds);

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
