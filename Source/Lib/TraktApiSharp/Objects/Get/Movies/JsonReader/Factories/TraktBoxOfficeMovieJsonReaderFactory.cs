namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktBoxOfficeMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktBoxOfficeMovie>
    {
        public ITraktObjectJsonReader<ITraktBoxOfficeMovie> CreateObjectReader() => new TraktBoxOfficeMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktBoxOfficeMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktBoxOfficeMovie)} is not supported.");
        }
    }
}
