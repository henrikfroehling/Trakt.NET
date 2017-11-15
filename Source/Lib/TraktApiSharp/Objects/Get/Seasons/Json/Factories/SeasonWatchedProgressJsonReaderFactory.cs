namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Objects.Json;

    internal class SeasonWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktSeasonWatchedProgress>
    {
        public IObjectJsonReader<ITraktSeasonWatchedProgress> CreateObjectReader() => new SeasonWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonWatchedProgress> CreateArrayReader() => new SeasonWatchedProgressArrayJsonReader();
    }
}
