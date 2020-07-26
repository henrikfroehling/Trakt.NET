namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserStatistics>
    {
        public IObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new UserStatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserStatistics> CreateObjectWriter() => new UserStatisticsObjectJsonWriter();
    }
}
