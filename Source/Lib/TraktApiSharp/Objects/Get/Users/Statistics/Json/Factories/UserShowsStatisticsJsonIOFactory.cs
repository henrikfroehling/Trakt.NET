namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserShowsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserShowsStatistics>
    {
        public IObjectJsonReader<ITraktUserShowsStatistics> CreateObjectReader() => new UserShowsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserShowsStatistics> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserShowsStatistics)} is not supported.");

        public IObjectJsonWriter<ITraktUserShowsStatistics> CreateObjectWriter() => new UserShowsStatisticsObjectJsonWriter();
    }
}
