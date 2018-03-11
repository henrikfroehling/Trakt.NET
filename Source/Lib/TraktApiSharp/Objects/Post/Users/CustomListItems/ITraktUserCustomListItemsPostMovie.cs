namespace TraktApiSharp.Objects.Post.Users.CustomListItems
{
    using Get.Movies;

    public interface ITraktUserCustomListItemsPostMovie
    {
        ITraktMovieIds Ids { get; set; }
    }
}
