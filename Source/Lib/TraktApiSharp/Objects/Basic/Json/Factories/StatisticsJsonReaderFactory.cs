namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System;

    internal class StatisticsJsonReaderFactory : IJsonIOFactory<ITraktStatistics>
    {
        public IObjectJsonReader<ITraktStatistics> CreateObjectReader() => new StatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
