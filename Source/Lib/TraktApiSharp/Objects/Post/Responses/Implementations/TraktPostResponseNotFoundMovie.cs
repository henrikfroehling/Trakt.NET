namespace TraktApiSharp.Objects.Post.Responses.Implementations
{
    using Get.Movies;

    public class TraktPostResponseNotFoundMovie : ITraktPostResponseNotFoundMovie
    {
        public ITraktMovieIds Ids { get; set; }
    }
}
