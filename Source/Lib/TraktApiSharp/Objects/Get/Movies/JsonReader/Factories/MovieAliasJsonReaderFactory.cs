namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class MovieAliasJsonReaderFactory : IJsonReaderFactory<ITraktMovieAlias>
    {
        public IObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new MovieAliasObjectJsonReader();

        public IArrayJsonReader<ITraktMovieAlias> CreateArrayReader() => new MovieAliasArrayJsonReader();
    }
}
