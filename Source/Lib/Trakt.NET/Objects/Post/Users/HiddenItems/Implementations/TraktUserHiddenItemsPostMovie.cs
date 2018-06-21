namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Movies;

    public class TraktUserHiddenItemsPostMovie : ITraktUserHiddenItemsPostMovie
    {
        public string Title { get; set; }

        public int? Year { get; set; }

        public ITraktMovieIds Ids { get; set; }
    }
}
