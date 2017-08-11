namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMovieAliasJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieAlias>
    {
        public ITraktObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new TraktMovieAliasObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieAlias> CreateArrayReader() => new TraktMovieAliasArrayJsonReader();
    }
}
