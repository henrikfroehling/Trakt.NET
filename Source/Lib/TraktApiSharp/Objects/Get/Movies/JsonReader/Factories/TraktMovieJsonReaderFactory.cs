namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktMovie>
    {
        public ITraktObjectJsonReader<ITraktMovie> CreateObjectReader() => new TraktMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMovie)} is not supported.");
        }
    }
}
