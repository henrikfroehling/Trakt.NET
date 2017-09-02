namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchedShowSeasonJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShowSeason>
    {
        public IObjectJsonReader<ITraktWatchedShowSeason> CreateObjectReader() => new WatchedShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowSeason> CreateArrayReader() => new WatchedShowSeasonArrayJsonReader();
    }
}
