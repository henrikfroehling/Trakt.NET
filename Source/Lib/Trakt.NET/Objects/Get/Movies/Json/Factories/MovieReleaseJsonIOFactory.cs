namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieReleaseJsonIOFactory : IJsonIOFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IObjectJsonWriter<ITraktMovieRelease> CreateObjectWriter() => new MovieReleaseObjectJsonWriter();
    }
}
