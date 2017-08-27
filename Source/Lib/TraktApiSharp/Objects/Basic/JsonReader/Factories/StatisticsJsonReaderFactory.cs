namespace TraktApiSharp.Objects.Basic.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class StatisticsJsonReaderFactory : IJsonReaderFactory<ITraktStatistics>
    {
        public IObjectJsonReader<ITraktStatistics> CreateObjectReader() => new TraktStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktStatistics)} is not supported.");
        }
    }
}
