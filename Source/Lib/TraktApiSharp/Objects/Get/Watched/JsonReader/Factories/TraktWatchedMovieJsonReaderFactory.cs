namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktWatchedMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedMovie>
    {
        public ITraktObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new TraktWatchedMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktWatchedMovie)} is not supported.");
        }
    }
}
