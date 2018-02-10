namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class TrendingMovieJsonIOFactory : IJsonIOFactory<ITraktTrendingMovie>
    {
        public IObjectJsonReader<ITraktTrendingMovie> CreateObjectReader() => new TrendingMovieObjectJsonReader();

        public IArrayJsonReader<ITraktTrendingMovie> CreateArrayReader() => new TrendingMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktTrendingMovie> CreateObjectWriter() => new TrendingMovieObjectJsonWriter();

        public IArrayJsonWriter<ITraktTrendingMovie> CreateArrayWriter() => new TrendingMovieArrayJsonWriter();
    }
}
