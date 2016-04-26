namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktSyncPostResponseNotFoundMovie
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
