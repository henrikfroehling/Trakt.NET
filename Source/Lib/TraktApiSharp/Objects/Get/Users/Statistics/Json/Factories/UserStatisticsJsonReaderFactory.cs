namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserStatistics>
    {
        public IObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new UserStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
