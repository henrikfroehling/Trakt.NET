namespace TraktApiSharp.Objects.Get.Movies.Json.Factories.Reader
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieAliasJsonReaderFactory : IJsonReaderFactory<ITraktMovieAlias>
    {
        public IObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new MovieAliasObjectJsonReader();

        public IArrayJsonReader<ITraktMovieAlias> CreateArrayReader() => new MovieAliasArrayJsonReader();
    }
}
