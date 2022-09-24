namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Get.Movies;

    /// <summary>An user personal list items post movie, containing the required movie ids.</summary>
    public interface ITraktUserPersonalListItemsPostMovie
    {
        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }

        /// <summary>Gets or sets the movie notes.</summary>
        string Notes { get; set; }
    }
}
