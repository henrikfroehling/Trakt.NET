namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserMoviesStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserMoviesStatistics>
    {
        public IObjectJsonReader<ITraktUserMoviesStatistics> CreateObjectReader() => new UserMoviesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserMoviesStatistics> CreateArrayReader() => new UserMoviesStatisticsArrayJsonReader();

        public IObjectJsonWriter<ITraktUserMoviesStatistics> CreateObjectWriter() => new UserMoviesStatisticsObjectJsonWriter();
    }
}
