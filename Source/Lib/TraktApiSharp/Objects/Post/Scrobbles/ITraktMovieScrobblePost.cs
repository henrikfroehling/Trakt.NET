namespace TraktNet.Objects.Post.Scrobbles
{
    using Get.Movies;

    public interface ITraktMovieScrobblePost : ITraktScrobblePost
    {
        ITraktMovie Movie { get; set; }
    }
}
