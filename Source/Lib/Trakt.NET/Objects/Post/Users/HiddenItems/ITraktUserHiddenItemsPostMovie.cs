namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Movies;

    /// <summary>An user hidden items post movie, containing the required movie ids.</summary>
    public interface ITraktUserHiddenItemsPostMovie
    {
        /// <summary>Gets or sets the movie title.</summary>
        string Title { get; set; }

        /// <summary>Gets or sets the movie year.</summary>
        int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        ITraktMovieIds Ids { get; set; }
    }
}
