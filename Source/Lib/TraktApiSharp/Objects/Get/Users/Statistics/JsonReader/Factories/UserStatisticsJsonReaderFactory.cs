namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserStatistics>
    {
        public IObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new UserStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }
    }
}
