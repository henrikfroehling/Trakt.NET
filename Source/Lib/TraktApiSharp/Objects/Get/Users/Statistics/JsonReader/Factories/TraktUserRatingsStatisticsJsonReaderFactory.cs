namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserRatingsStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserRatingsStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new TraktUserRatingsStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserRatingsStatistics)} is not supported.");
        }
    }
}
