namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieReleaseJsonReaderFactory : IJsonIOFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new MovieReleaseArrayJsonReader();

        public IObjectJsonReader<ITraktMovieRelease> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
