namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories.Reader
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserRatingsStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserRatingsStatistics>
    {
        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new UserRatingsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserRatingsStatistics)} is not supported.");
        }
    }
}
