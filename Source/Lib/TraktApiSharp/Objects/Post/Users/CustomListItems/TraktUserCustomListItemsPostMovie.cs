namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Movies;
    using Newtonsoft.Json;

    /// <summary>An user custom list items post movie, containing the required movie ids.</summary>
    public class TraktUserCustomListItemsPostMovie
    {
        /// <summary>Gets or sets the required movie ids. See also <seealso cref="TraktMovieIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }
    }
}
