namespace TraktApiSharp.Objects.Post.Responses
{
    using Get.Movies;

    public interface ITraktPostResponseNotFoundMovie
    {
        ITraktMovieIds Ids { get; set; }
    }
}
