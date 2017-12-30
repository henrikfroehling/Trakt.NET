namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserShowsStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserShowsStatistics>
    {
        public IObjectJsonReader<ITraktUserShowsStatistics> CreateObjectReader() => new UserShowsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserShowsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserShowsStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserShowsStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserShowsStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
