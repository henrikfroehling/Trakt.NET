namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories.Reader
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserSeasonsStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserSeasonsStatistics>
    {
        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new UserSeasonsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSeasonsStatistics)} is not supported.");
        }
    }
}
