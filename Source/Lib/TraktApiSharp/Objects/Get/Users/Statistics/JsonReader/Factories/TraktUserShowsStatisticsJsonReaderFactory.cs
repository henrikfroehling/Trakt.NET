namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserShowsStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserShowsStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserShowsStatistics> CreateObjectReader() => new TraktUserShowsStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserShowsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserShowsStatistics)} is not supported.");
        }
    }
}
