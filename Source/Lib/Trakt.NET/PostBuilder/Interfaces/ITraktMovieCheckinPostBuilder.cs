namespace TraktNet.PostBuilder
{
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;

    public interface ITraktMovieCheckinPostBuilder : ITraktCheckinPostBuilder<ITraktMovieCheckinPostBuilder, ITraktMovieCheckinPost>
    {
        ITraktMovieCheckinPostBuilder WithMovie(ITraktMovie movie);
    }
}
