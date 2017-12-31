namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserStatistics>
    {
        public IObjectJsonReader<ITraktUserStatistics> CreateObjectReader() => new UserStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserStatistics)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
