namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class MovieReleaseJsonReaderFactory : IJsonReaderFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new MovieReleaseArrayJsonReader();
    }
}
