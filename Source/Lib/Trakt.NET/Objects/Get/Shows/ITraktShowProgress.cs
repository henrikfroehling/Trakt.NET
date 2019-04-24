namespace TraktNet.Objects.Get.Shows
{
    using Episodes;
    using Seasons;
    using System.Collections.Generic;

    /// <summary>Represents the progress of a Trakt show.</summary>
    public interface ITraktShowProgress
    {
        /// <summary>Gets or sets the number of episodes, which already aired.</summary>
        int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes already collected or watched.</summary>
        int? Completed { get; set; }

        /// <summary>
        /// Gets or sets the hidden seasons. See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktSeason> HiddenSeasons { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user should collect or watch.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode NextEpisode { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user collected or watched last.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktEpisode LastEpisode { get; set; }
    }
}
