namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new TraktUserStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }
    }
}
