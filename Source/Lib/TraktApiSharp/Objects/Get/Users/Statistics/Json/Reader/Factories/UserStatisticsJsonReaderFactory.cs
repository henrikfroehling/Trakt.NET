namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories.Reader
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserStatistics>
    {
        public IObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new UserStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }
    }
}
