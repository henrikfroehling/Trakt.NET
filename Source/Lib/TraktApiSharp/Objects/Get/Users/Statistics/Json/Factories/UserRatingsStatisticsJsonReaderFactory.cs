namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserRatingsStatisticsJsonReaderFactory : IJsonIOFactory<ITraktUserRatingsStatistics>
    {
        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new UserRatingsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserRatingsStatistics)} is not supported.");
        }

        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
