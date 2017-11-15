namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserEpisodesStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserEpisodesStatistics>
    {
        public IObjectJsonReader<ITraktUserEpisodesStatistics> CreateObjectReader() => new UserEpisodesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserEpisodesStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserEpisodesStatistics)} is not supported.");
        }
    }
}
