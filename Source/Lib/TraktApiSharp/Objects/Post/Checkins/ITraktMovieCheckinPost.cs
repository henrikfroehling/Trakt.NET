namespace TraktNet.Objects.Post.Checkins
{
    using Get.Movies;

    public interface ITraktMovieCheckinPost : ITraktCheckinPost
    {
        ITraktMovie Movie { get; set; }
    }
}
