namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MostRecommendedMovieJsonIOFactory : IJsonIOFactory<ITraktMostRecommendedMovie>
    {
        public IObjectJsonReader<ITraktMostRecommendedMovie> CreateObjectReader() => new MostRecommendedMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktMostRecommendedMovie> CreateObjectWriter() => new MostRecommendedMovieObjectJsonWriter();
    }
}
