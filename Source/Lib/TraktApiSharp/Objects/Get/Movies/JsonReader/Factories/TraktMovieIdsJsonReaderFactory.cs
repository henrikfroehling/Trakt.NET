namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieIdsJsonReaderFactory : IJsonReaderFactory<ITraktMovieIds>
    {
        public ITraktObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new TraktMovieIdsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovieIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieIds)} is not supported.");
        }
    }
}
