namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktTrendingMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktTrendingMovie>
    {
        public ITraktObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TraktTrendingMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktTrendingMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktTrendingMovie)} is not supported.");
        }
    }
}
