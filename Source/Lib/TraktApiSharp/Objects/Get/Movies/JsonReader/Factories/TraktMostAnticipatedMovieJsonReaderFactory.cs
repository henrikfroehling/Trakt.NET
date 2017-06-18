namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMostAnticipatedMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostAnticipatedMovie>
    {
        public ITraktObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new TraktMostAnticipatedMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMostAnticipatedMovie)} is not supported.");
        }
    }
}
