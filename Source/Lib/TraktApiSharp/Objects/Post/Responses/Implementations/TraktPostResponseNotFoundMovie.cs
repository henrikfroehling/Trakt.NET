namespace TraktApiSharp.Objects.Post.Responses
{
    using Get.Movies;

    public class TraktPostResponseNotFoundMovie : ITraktPostResponseNotFoundMovie
    {
        public ITraktMovieIds Ids { get; set; }
    }
}
