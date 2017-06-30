namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations
{
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>Represents a movie scrobble response.</summary>
    public class TraktMovieScrobblePostResponse : TraktScrobblePostResponse, ITraktMovieScrobblePostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was scrobbled.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public ITraktMovie Movie { get; set; }
    }
}
