namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MovieAliasJsonReaderFactory : IJsonIOFactory<ITraktMovieAlias>
    {
        public IObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new MovieAliasObjectJsonReader();

        public IArrayJsonReader<ITraktMovieAlias> CreateArrayReader() => new MovieAliasArrayJsonReader();

        public IObjectJsonReader<ITraktMovieAlias> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieAlias> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
