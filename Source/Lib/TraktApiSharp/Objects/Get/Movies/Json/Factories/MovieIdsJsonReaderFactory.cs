namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;
    using System;

    internal class MovieIdsJsonReaderFactory : IJsonIOFactory<ITraktMovieIds>
    {
        public IObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new MovieIdsObjectJsonReader();

        public IArrayJsonReader<ITraktMovieIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieIds)} is not supported.");
        }

        public IObjectJsonReader<ITraktMovieIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktMovieIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
