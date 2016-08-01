namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;

    /// <summary>A anticipated Trakt movie.</summary>
    public class TraktMostAnticipatedMovie
    {
        /// <summary>Gets or sets the list count for the <see cref="Movie" />.</summary>
        [JsonProperty(PropertyName = "list_count")]
        public int? ListCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}
