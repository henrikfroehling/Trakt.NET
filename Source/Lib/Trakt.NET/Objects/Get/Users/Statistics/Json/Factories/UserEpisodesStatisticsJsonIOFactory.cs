namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserEpisodesStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserEpisodesStatistics>
    {
        public IObjectJsonReader<ITraktUserEpisodesStatistics> CreateObjectReader() => new UserEpisodesStatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserEpisodesStatistics> CreateObjectWriter() => new UserEpisodesStatisticsObjectJsonWriter();
    }
}
