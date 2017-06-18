namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserSeasonsStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserSeasonsStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new TraktUserSeasonsStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSeasonsStatistics)} is not supported.");
        }
    }
}
