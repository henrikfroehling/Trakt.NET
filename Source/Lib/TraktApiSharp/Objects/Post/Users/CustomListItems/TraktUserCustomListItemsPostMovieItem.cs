namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktUserCustomListItemsPostMovieItem
    {
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
