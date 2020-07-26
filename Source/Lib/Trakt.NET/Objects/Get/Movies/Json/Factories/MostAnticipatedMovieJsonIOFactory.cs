namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MostAnticipatedMovieJsonIOFactory : IJsonIOFactory<ITraktMostAnticipatedMovie>
    {
        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new MostAnticipatedMovieObjectJsonReader();

        public IObjectJsonWriter<ITraktMostAnticipatedMovie> CreateObjectWriter() => new MostAnticipatedMovieObjectJsonWriter();
    }
}
