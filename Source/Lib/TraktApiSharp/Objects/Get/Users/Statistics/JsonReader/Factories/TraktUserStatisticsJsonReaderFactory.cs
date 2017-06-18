namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new TraktUserStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }
    }
}
