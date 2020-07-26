namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserRatingsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserRatingsStatistics>
    {
        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new UserRatingsStatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserRatingsStatistics> CreateObjectWriter() => new UserRatingsStatisticsObjectJsonWriter();
    }
}
