namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Get.Movies.Json.Reader;
    using Get.Movies.Json.Writer;
    using Objects.Json;

    internal class RecentlyUpdatedMovieJsonIOFactory : IJsonIOFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktRecentlyUpdatedMovie> CreateObjectWriter() => new RecentlyUpdatedMovieObjectJsonWriter();

        public IArrayJsonWriter<ITraktRecentlyUpdatedMovie> CreateArrayWriter() => new RecentlyUpdatedMovieArrayJsonWriter();
    }
}
