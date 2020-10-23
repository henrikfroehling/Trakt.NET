namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class StatisticsJsonIOFactory : IJsonIOFactory<ITraktStatistics>
    {
        public IObjectJsonReader<ITraktStatistics> CreateObjectReader() => new StatisticsObjectJsonReader();

        public IObjectJsonWriter<ITraktStatistics> CreateObjectWriter() => new StatisticsObjectJsonWriter();
    }
}
