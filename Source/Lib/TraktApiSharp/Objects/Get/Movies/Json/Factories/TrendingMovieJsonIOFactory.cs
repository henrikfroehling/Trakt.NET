namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class TrendingMovieJsonIOFactory : IJsonIOFactory<ITraktTrendingMovie>
    {
        public IObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TrendingMovieObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingMovie> CreateArrayReader() => new TrendingMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktTrendingMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktTrendingMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
