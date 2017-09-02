namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class UserRatingsStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserRatingsStatistics>
    {
        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new TraktUserRatingsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserRatingsStatistics)} is not supported.");
        }
    }
}
