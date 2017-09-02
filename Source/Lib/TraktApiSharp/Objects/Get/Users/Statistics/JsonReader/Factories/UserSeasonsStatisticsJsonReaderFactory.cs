namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserSeasonsStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserSeasonsStatistics>
    {
        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new UserSeasonsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSeasonsStatistics)} is not supported.");
        }
    }
}
