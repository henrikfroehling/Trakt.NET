namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MostPWCMovieJsonReaderFactory : IJsonIOFactory<ITraktMostPWCMovie>
    {
        public IObjectJsonReader<ITraktMostPWCMovie> CreateObjectReader() => new MostPWCMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCMovie> CreateArrayReader() => new MostPWCMovieArrayJsonReader();

        public IObjectJsonReader<ITraktMostPWCMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktMostPWCMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
