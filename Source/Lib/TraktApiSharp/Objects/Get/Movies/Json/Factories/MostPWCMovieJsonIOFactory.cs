namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class MostPWCMovieJsonIOFactory : IJsonIOFactory<ITraktMostPWCMovie>
    {
        public IObjectJsonReader<ITraktMostPWCMovie> CreateObjectReader() => new MostPWCMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCMovie> CreateArrayReader() => new MostPWCMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktMostPWCMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktMostPWCMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
