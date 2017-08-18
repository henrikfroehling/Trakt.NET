namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktMostPWCMovieJsonReaderFactory : IJsonReaderFactory<ITraktMostPWCMovie>
    {
        public ITraktObjectJsonReader<ITraktMostPWCMovie> CreateObjectReader() => new TraktMostPWCMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktMostPWCMovie> CreateArrayReader() => new TraktMostPWCMovieArrayJsonReader();
    }
}
