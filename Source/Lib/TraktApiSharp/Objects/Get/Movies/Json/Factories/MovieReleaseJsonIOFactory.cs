namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieReleaseJsonIOFactory : IJsonIOFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new MovieReleaseArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieRelease> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMovieRelease> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
