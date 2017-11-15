namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Objects.Json;
    using System;

    internal class UserMoviesStatisticsJsonReaderFactory : IJsonReaderFactory<ITraktUserMoviesStatistics>
    {
        public IObjectJsonReader<ITraktUserMoviesStatistics> CreateObjectReader() => new UserMoviesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserMoviesStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserMoviesStatistics)} is not supported.");
        }
    }
}
