namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class MostAnticipatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedMovie>
    {
        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new MostAnticipatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader() => new MostAnticipatedMovieArrayJsonReader();
    }
}
