namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SeasonWatchedProgressJsonReaderFactory : IJsonReaderFactory<ITraktSeasonWatchedProgress>
    {
        public IObjectJsonReader<ITraktSeasonWatchedProgress> CreateObjectReader() => new TraktSeasonWatchedProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonWatchedProgress> CreateArrayReader() => new TraktSeasonWatchedProgressArrayJsonReader();
    }
}
