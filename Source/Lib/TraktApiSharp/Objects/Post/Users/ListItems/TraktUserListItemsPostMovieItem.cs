namespace TraktApiSharp.Objects.Post.Users.ListItems
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktUserListItemsPostMovieItem
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
