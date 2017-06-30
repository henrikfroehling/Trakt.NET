namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieAliasJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovieAlias>
    {
        public ITraktObjectJsonReader<ITraktMovieAlias> CreateObjectReader() => new TraktMovieAliasObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieAlias> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieAlias)} is not supported.");
        }
    }
}
