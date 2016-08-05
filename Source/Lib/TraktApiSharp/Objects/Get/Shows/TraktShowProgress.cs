namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Episodes;
    using Newtonsoft.Json;
    using Seasons;
    using System.Collections.Generic;

    /// <summary>Represents the progress of a Trakt show.</summary>
    public abstract class TraktShowProgress
    {
        /// <summary>Gets or sets the number of episodes, which already aired.</summary>
        [JsonProperty(PropertyName = "aired")]
        public int? Aired { get; set; }

        /// <summary>Gets or sets the number of episodes already collected or watched.</summary>
        [JsonProperty(PropertyName = "completed")]
        public int? Completed { get; set; }

        /// <summary>
        /// Gets or sets the hidden seasons. See also <seealso cref="TraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "hidden_seasons")]
        [Nullable]
        public IEnumerable<TraktSeason> HiddenSeasons { get; set; }

        /// <summary>
        /// Gets or sets the episode, which the user should collect or watch.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "next_episode")]
        [Nullable]
        public TraktEpisode NextEpisode { get; set; }
    }
}
