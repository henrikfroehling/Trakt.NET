namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedMovieJsonReaderFactory : IJsonIOFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();

        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
