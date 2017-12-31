namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;
    using System;

    internal class MovieIdsJsonIOFactory : IJsonIOFactory<ITraktMovieIds>
    {
        public IObjectJsonReader<ITraktMovieIds> CreateObjectReader() => new MovieIdsObjectJsonReader();

        public IArrayJsonReader<ITraktMovieIds> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovieIds)} is not supported.");
        }

        public IObjectJsonWriter<ITraktMovieIds> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMovieIds> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
