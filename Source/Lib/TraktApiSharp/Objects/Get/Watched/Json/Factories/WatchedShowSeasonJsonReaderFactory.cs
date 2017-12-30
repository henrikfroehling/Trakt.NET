namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowSeasonJsonReaderFactory : IJsonIOFactory<ITraktWatchedShowSeason>
    {
        public IObjectJsonReader<ITraktWatchedShowSeason> CreateObjectReader() => new WatchedShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowSeason> CreateArrayReader() => new WatchedShowSeasonArrayJsonReader();

        public IObjectJsonReader<ITraktWatchedShowSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktWatchedShowSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
