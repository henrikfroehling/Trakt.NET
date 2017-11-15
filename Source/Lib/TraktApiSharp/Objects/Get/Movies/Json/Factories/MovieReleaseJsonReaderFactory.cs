namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class MovieReleaseJsonReaderFactory : IJsonReaderFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new MovieReleaseArrayJsonReader();
    }
}
