namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserShowsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserShowsStatistics>
    {
        public IObjectJsonReader<ITraktUserShowsStatistics> CreateObjectReader() => new UserShowsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserShowsStatistics> CreateArrayReader() => new UserShowsStatisticsArrayJsonReader();

        public IObjectJsonWriter<ITraktUserShowsStatistics> CreateObjectWriter() => new UserShowsStatisticsObjectJsonWriter();
    }
}
