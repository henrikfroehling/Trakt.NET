namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
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
