namespace TraktNet.Objects.Post.Users.CustomListItems
{
    using Get.Movies;

    /// <summary>An user custom list items post movie, containing the required movie ids.</summary>
    public interface ITraktUserCustomListItemsPostMovie
    {
        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
