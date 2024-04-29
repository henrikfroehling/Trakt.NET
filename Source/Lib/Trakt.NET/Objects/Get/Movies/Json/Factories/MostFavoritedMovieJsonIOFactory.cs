namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MostFavoritedMovieJsonIOFactory : IJsonIOFactory<ITraktMostFavoritedMovie>
    {
        public IObjectJsonReader<ITraktMostFavoritedMovie> CreateObjectReader() => new MostFavoritedMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktMostFavoritedMovie> CreateObjectWriter() => new MostFavoritedMovieObjectJsonWriter();
    }
}
