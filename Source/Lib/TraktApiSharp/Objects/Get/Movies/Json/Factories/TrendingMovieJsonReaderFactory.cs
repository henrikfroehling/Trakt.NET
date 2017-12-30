namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class TrendingMovieJsonReaderFactory : IJsonIOFactory<ITraktTrendingMovie>
    {
        public IObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TrendingMovieObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingMovie> CreateArrayReader() => new TrendingMovieArrayJsonReader();

        public IObjectJsonReader<ITraktTrendingMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktTrendingMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
