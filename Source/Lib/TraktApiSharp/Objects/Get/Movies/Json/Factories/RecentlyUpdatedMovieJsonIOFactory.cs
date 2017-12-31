namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedMovieJsonIOFactory : IJsonIOFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktRecentlyUpdatedMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktRecentlyUpdatedMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
