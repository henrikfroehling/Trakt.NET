namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktTrendingMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktTrendingMovie>
    {
        public ITraktObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TraktTrendingMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktTrendingMovie> CreateArrayReader() => new TraktTrendingMovieArrayJsonReader();
    }
}
