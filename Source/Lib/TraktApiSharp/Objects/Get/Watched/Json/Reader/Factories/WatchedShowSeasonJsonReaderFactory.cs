namespace TraktApiSharp.Objects.Get.Watched.Json.Factories.Reader
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowSeasonJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShowSeason>
    {
        public IObjectJsonReader<ITraktWatchedShowSeason> CreateObjectReader() => new WatchedShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowSeason> CreateArrayReader() => new WatchedShowSeasonArrayJsonReader();
    }
}
