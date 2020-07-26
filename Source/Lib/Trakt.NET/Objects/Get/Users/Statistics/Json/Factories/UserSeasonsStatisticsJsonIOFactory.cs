namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserSeasonsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserSeasonsStatistics>
    {
        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new UserSeasonsStatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserSeasonsStatistics> CreateObjectWriter() => new UserSeasonsStatisticsObjectJsonWriter();
    }
}
