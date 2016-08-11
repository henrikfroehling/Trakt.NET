namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonMovieCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "job")]
        [Nullable]
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the movie of the crew position. See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
