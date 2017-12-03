namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories.Reader
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktSeasonWatchedProgress>
    {
        public IObjectJsonReader<ITraktSeasonWatchedProgress> CreateObjectReader() => new SeasonWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonWatchedProgress> CreateArrayReader() => new SeasonWatchedProgressArrayJsonReader();
    }
}
