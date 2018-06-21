namespace TraktNet.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class MostPWCMovieJsonIOFactory : IJsonIOFactory<ITraktMostPWCMovie>
    {
        public IObjectJsonReader<ITraktMostPWCMovie> CreateObjectReader() => new MostPWCMovieObjectJsonReader();

        public IArrayJsonReader<ITraktMostPWCMovie> CreateArrayReader() => new MostPWCMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktMostPWCMovie> CreateObjectWriter() => new MostPWCMovieObjectJsonWriter();
    }
}
