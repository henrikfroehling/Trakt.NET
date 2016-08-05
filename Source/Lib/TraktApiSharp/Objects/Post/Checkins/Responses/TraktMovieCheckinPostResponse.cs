namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Attributes;
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieCheckinPostResponse : TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}
