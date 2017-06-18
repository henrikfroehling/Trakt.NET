namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktMostPWCMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktMostPWCMovie>
    {
        public ITraktObjectJsonReader<ITraktMostPWCMovie> CreateObjectReader() => new TraktMostPWCMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostPWCMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktMostPWCMovie)} is not supported.");
        }
    }
}
