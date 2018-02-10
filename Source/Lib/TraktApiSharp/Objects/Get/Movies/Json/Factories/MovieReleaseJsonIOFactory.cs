namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieReleaseJsonIOFactory : IJsonIOFactory<ITraktMovieRelease>
    {
        public IObjectJsonReader<ITraktMovieRelease> CreateObjectReader() => new MovieReleaseObjectJsonReader();

        public IArrayJsonReader<ITraktMovieRelease> CreateArrayReader() => new MovieReleaseArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieRelease> CreateObjectWriter() => new MovieReleaseObjectJsonWriter();

        public IArrayJsonWriter<ITraktMovieRelease> CreateArrayWriter() => new MovieReleaseArrayJsonWriter();
    }
}
