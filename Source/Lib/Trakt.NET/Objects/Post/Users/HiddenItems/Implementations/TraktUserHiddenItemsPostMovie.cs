namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Movies;

    /// <summary>An user hidden items post movie, containing the required movie ids.</summary>
    public class TraktUserHiddenItemsPostMovie : ITraktUserHiddenItemsPostMovie
    {
        /// <summary>Gets or sets the movie title.</summary>
        public string Title { get; set; }

        /// <summary>Gets or sets the movie year.</summary>
        public int? Year { get; set; }

        /// <summary>Gets or sets the required movie ids. See also <seealso cref="ITraktMovieIds" />.</summary>
        public ITraktMovieIds Ids { get; set; }
    }
}
