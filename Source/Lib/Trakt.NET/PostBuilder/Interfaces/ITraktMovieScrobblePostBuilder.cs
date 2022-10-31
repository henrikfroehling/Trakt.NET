namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Scrobbles;

    public interface ITraktMovieScrobblePostBuilder : ITraktScrobblePostBuilder<ITraktMovieScrobblePostBuilder, ITraktMovieScrobblePost>
    {
        ITraktMovieScrobblePostBuilder WithMovie(ITraktMovie movie);
    }
}
