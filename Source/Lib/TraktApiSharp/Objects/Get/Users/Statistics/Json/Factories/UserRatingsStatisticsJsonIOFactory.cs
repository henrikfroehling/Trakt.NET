namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserRatingsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserRatingsStatistics>
    {
        public IObjectJsonReader<ITraktUserRatingsStatistics> CreateObjectReader() => new UserRatingsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserRatingsStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserRatingsStatistics)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserRatingsStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserRatingsStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
