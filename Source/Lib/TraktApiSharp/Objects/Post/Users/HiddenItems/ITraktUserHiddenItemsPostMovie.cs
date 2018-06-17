namespace TraktApiSharp.Objects.Post.Users.HiddenItems
{
    using Get.Movies;

    public interface ITraktUserHiddenItemsPostMovie
    {
        string Title { get; set; }

        int? Year { get; set; }

        ITraktMovieIds Ids { get; set; }
    }
}
