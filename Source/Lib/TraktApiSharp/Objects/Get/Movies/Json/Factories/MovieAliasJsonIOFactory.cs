namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MovieAliasJsonIOFactory : IJsonIOFactory<ITraktMovieAlias>
    {
        public IObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new MovieAliasObjectJsonReader();

        public IArrayJsonReader<ITraktMovieAlias> CreateArrayReader() => new MovieAliasArrayJsonReader();

        public IObjectJsonWriter<ITraktMovieAlias> CreateObjectWriter() => new MovieAliasObjectJsonWriter();

        public IArrayJsonWriter<ITraktMovieAlias> CreateArrayWriter() => new MovieAliasArrayJsonWriter();
    }
}
