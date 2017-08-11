namespace TraktApiSharp.Objects.Get.Shows.Implementations
{
    using Episodes;
    using Seasons;
    using System.Collections.Generic;

    /// <summary>Represents the progress of a Trakt show.</summary>
    public abstract class TraktShowProgress : ITraktShowProgress
    {
        /// <summary>Gets or sets the number of episodes, which already aired.</summary>
        public int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes already collected or watched.</summary>
        public int? Completed { get; set; }

        /// <summary>
        /// Gets or sets the hidden seasons. See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktSeason> HiddenSeasons { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user should collect or watch.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode NextEpisode { get; set; }
    }
}
