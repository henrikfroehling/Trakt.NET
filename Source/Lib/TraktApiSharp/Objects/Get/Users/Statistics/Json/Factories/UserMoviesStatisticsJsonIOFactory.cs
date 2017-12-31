namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Factories
{
    using Get.Users.Statistics.Json.Reader;
    using Objects.Json;
    using System;

    internal class UserMoviesStatisticsJsonIOFactory : IJsonIOFactory<ITraktUserMoviesStatistics>
    {
        public IObjectJsonReader<ITraktUserMoviesStatistics> CreateObjectReader() => new UserMoviesStatisticsObjectJsonReader();

        public IArrayJsonReader<ITraktUserMoviesStatistics> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktUserMoviesStatistics)} is not supported.");
        }

        public IObjectJsonWriter<ITraktUserMoviesStatistics> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktUserMoviesStatistics> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
