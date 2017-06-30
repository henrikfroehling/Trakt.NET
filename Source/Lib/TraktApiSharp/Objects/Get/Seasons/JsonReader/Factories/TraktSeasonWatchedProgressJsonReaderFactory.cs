namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSeasonWatchedProgressJsonReaderFactory : ITraktJsonReaderFactory<ITraktSeasonWatchedProgress>
    {
        public ITraktObjectJsonReader<ITraktSeasonWatchedProgress> CreateObjectReader() => new TraktSeasonWatchedProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSeasonWatchedProgress> CreateArrayReader() => new TraktSeasonWatchedProgressArrayJsonReader();
    }
}
