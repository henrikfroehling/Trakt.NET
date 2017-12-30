namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserNetworkStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserNetworkStatistics>
    {
        public IObjectJsonReader<ITraktUserNetworkStatistics> CreateObjectReader() => new UserNetworkStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserNetworkStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserNetworkStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserNetworkStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserNetworkStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
