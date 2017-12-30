namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserSeasonsStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserSeasonsStatistics>
    {
        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new UserSeasonsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSeasonsStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
