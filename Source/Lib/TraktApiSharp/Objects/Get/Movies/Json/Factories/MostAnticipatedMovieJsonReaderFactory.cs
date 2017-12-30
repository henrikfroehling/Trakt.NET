namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MostAnticipatedMovieJsonReaderFactory : IJsonIOFactory<ITraktMostAnticipatedMovie>
    {
        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new MostAnticipatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader() => new MostAnticipatedMovieArrayJsonReader();

        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
