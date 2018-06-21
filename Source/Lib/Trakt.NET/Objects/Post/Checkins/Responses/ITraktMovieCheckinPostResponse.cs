namespace TraktNet.Objects.Post.Checkins.Responses
{
    using Get.Movies;

    public interface ITraktMovieCheckinPostResponse : ITraktCheckinPostResponse
    {
        ITraktMovie Movie { get; set; }
    }
}
