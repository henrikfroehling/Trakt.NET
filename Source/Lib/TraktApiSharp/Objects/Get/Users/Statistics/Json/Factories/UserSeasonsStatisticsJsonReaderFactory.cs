namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
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
