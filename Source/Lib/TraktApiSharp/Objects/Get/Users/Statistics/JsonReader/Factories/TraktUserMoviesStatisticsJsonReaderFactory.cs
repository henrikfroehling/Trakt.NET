namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktUserMoviesStatisticsJsonReaderFactory : ITraktJsonReaderFactory<ITraktUserMoviesStatistics>
    {
        public ITraktObjectJsonReader<ITraktUserMoviesStatistics> CreateObjectReader() => new TraktUserMoviesStatisticsObjectJsonReader();

        public ITraktArrayJsonReader<ITraktUserMoviesStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserMoviesStatistics)} is not supported.");
        }
    }
}
