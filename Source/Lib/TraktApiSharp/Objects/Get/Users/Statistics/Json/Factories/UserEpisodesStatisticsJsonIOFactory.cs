namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserEpisodesStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserEpisodesStatistics>
    {
        public IObjectJsonReader<ITraktUserEpisodesStatistics> CreateObjectReader() => new UserEpisodesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserEpisodesStatistics> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserEpisodesStatistics)} is not supported.");

        public IObjectJsonWriter<ITraktUserEpisodesStatistics> CreateObjectWriter() => new UserEpisodesStatisticsObjectJsonWriter();

        public IArrayJsonWriter<ITraktUserEpisodesStatistics> CreateArrayWriter()
            => throw new NotSupportedException($"A array json writer for {nameof(ITraktUserEpisodesStatistics)} is not supported.");
    }
}
