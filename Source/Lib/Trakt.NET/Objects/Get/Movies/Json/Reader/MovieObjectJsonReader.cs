namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    internal class MovieObjectJsonReader : AMovieObjectJsonReader<ITraktMovie>
    {
        protected override ITraktMovie CreateMovieObject() => new TraktMovie();
    }
}
