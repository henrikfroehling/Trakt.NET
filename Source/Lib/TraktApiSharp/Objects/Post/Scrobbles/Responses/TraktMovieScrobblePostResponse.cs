namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Get.Movies.Implementations;
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
        public TraktMovie Movie { get; set; }
    }
}
