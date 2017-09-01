namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class MostAnticipatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedMovie>
    {
        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new TraktMostAnticipatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader() => new MostAnticipatedMovieArrayJsonReader();
    }
}
