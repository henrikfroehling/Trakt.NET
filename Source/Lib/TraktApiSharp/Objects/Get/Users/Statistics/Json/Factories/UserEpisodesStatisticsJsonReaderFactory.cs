namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserEpisodesStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserEpisodesStatistics>
    {
        public IObjectJsonReader<ITraktUserEpisodesStatistics> CreateObjectReader() => new UserEpisodesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserEpisodesStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserEpisodesStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserEpisodesStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserEpisodesStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
