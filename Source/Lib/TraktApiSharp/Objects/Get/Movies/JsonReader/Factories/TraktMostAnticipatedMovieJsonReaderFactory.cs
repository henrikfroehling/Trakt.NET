namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMostAnticipatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktMostAnticipatedMovie>
    {
        public ITraktObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new TraktMostAnticipatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader() => new TraktMostAnticipatedMovieArrayJsonReader();
    }
}
