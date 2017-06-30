namespace TraktApiSharp.Objects.Post.Checkins.Responses.Implementations
{
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>Represents a movie checkin response.</summary>
    public class TraktMovieCheckinPostResponse : TraktCheckinPostResponse, ITraktMovieCheckinPostResponse
    {
        /// <summary>
        /// Gets or sets the Trakt movie, which was checked in.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public ITraktMovie Movie { get; set; }
    }
}
