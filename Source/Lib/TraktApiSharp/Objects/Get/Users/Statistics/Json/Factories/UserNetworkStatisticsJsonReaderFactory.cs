namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserNetworkStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserNetworkStatistics>
    {
        public IObjectJsonReader<ITraktUserNetworkStatistics> CreateObjectReader() => new UserNetworkStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserNetworkStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserNetworkStatistics)} is not supported.");
        }
    }
}
