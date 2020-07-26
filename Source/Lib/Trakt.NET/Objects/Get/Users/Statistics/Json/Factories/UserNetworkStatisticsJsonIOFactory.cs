namespace TraktNet.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;

    internal class UserNetworkStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserNetworkStatistics>
    {
        public IObjectJsonReader<ITraktUserNetworkStatistics> CreateObjectReader() => new UserNetworkStatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserNetworkStatistics> CreateObjectWriter() => new UserNetworkStatisticsObjectJsonWriter();
    }
}
