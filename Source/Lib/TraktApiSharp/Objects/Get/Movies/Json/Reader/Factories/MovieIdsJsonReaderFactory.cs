namespace TraktApiSharp.Objects.Get.Movies.Json.Factories.Reader
{
    using Get.Movies.Json.Reader;
    using Objects.Json;
    using System;

    internal class MovieIdsJsonReaderFactory : IJsonReaderFactory<ITraktMovieIds>
    {
        public IObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new MovieIdsObjectJsonReader();

        public IArrayJsonReader<ITraktMovieIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieIds)} is not supported.");
        }
    }
}
