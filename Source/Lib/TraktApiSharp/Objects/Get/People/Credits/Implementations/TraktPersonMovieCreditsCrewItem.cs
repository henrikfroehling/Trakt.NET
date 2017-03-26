namespace TraktApiSharp.Objects.Get.People.Credits.Implementations
{
    using Movies;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    /// <summary>Contains information about a Trakt person's crew position.</summary>
    public class TraktPersonMovieCreditsCrewItem : ITraktPersonMovieCreditsCrewItem
    {
        /// <summary>Gets or sets the job name of the crew position.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        /// <summary>
        /// Gets or sets the movie of the crew position. See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public ITraktMovie Movie { get; set; }
    }
}
