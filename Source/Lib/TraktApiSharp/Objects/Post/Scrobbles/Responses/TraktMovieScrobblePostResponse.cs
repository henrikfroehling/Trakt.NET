namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Attributes;
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>Represents a movie scrobble response.</summary>
    public class TraktMovieScrobblePostResponse : TraktScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was scrobbled.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
