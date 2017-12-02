namespace TraktApiSharp.Objects.Get.Movies.Json.Factories.Reader
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class TrendingMovieJsonReaderFactory : IJsonReaderFactory<ITraktTrendingMovie>
    {
        public IObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TrendingMovieObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingMovie> CreateArrayReader() => new TrendingMovieArrayJsonReader();
    }
}
