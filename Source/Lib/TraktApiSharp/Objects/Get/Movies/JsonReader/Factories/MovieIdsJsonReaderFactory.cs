namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class MovieIdsJsonReaderFactory : IJsonReaderFactory<ITraktMovieIds>
    {
        public IObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new TraktMovieIdsObjectJsonReader();

        public IArrayJsonReader<ITraktMovieIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieIds)} is not supported.");
        }
    }
}
