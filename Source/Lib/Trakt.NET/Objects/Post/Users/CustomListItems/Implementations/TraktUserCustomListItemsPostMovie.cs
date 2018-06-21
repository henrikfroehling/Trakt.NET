namespace TraktNet.Objects.Post.Users.CustomListItems
{
    using Get.Movies;

    /// <summary>An user custom list items post movie, containing the required movie ids.</summary>
    public class TraktUserCustomListItemsPostMovie : ITraktUserCustomListItemsPostMovie
    {
        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }
    }
}
