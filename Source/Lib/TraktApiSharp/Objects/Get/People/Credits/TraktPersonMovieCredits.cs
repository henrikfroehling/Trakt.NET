namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Contains all Trakt movies where a Trakt person is in the cast or crew.</summary>
    public class TraktPersonMovieCredits
    {
        /// <summary>
        /// Gets or sets a list of cast positions, in which a person is.
        /// See also <seealso cref="TraktPersonMovieCreditsCastItem" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "cast")]
        [Nullable]
        public IEnumerable<TraktPersonMovieCreditsCastItem> Cast { get; set; }

        /// <summary>
        /// Gets or sets a collection of crew positions, which a person has.
        /// See also <seealso cref="TraktPersonMovieCreditsCrew" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "crew")]
        [Nullable]
        public TraktPersonMovieCreditsCrew Crew { get; set; }
    }
}
