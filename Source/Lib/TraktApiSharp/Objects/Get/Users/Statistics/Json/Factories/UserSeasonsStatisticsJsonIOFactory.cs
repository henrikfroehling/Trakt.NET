namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Get.Users.Statistics.Json.Writer;
    using Objects.Json;
    using System;

    internal class UserSeasonsStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserSeasonsStatistics>
    {
        public IObjectJsonReader<ITraktUserSeasonsStatistics> CreateObjectReader() => new UserSeasonsStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserSeasonsStatistics> CreateArrayReader()
            => throw new NotSupportedException($"A array json reader for {nameof(ITraktUserSeasonsStatistics)} is not supported.");

        public IObjectJsonWriter<ITraktUserSeasonsStatistics> CreateObjectWriter() => new UserSeasonsStatisticsObjectJsonWriter();
    }
}
