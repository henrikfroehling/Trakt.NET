namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MostAnticipatedMovieJsonIOFactory : IJsonIOFactory<ITraktMostAnticipatedMovie>
    {
        public IObjectJsonReader<ITraktMostAnticipatedMovie> CreateObjectReader() => new MostAnticipatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostAnticipatedMovie> CreateArrayReader() => new MostAnticipatedMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktMostAnticipatedMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMostAnticipatedMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
