namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserShowsStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserShowsStatistics>
    {
        public IObjectJsonReader<ITraktUserShowsStatistics> CreateObjectReader() => new UserShowsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserShowsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserShowsStatistics)} is not supported.");
        }
    }
}
