namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktRecentlyUpdatedMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktRecentlyUpdatedMovie>
    {
        public ITraktObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new TraktRecentlyUpdatedMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktRecentlyUpdatedMovie)} is not supported.");
        }
    }
}
