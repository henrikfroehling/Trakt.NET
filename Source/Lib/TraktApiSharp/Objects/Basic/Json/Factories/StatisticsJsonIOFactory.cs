namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;
    using System;

    internal class StatisticsJsonIOFactory : IJsonIOFactory<ITraktStatistics>
    {
        public IObjectJsonReader<ITraktStatistics> CreateObjectReader() => new StatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktStatistics> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktStatistics)} is not supported.");

        public IObjectJsonWriter<ITraktStatistics> CreateObjectWriter() => new StatisticsObjectJsonWriter();
    }
}
