namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Get.Movies;

    public interface ITraktMovieScrobblePostResponse : ITraktScrobblePostResponse
    {
        ITraktMovie Movie { get; set; }
    }
}
