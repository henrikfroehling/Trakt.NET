namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowSeasonJsonIOFactory : IJsonIOFactory<ITraktWatchedShowSeason>
    {
        public IObjectJsonReader<ITraktWatchedShowSeason> CreateObjectReader() => new WatchedShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShowSeason> CreateArrayReader() => new WatchedShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktWatchedShowSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktWatchedShowSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
