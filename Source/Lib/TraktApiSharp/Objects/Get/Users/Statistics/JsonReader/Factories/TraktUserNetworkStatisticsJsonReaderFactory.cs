namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserNetworkStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserNetworkStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserNetworkStatistics> CreateObjectReader() => new TraktUserNetworkStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserNetworkStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserNetworkStatistics)} is not supported.");
        }
    }
}
