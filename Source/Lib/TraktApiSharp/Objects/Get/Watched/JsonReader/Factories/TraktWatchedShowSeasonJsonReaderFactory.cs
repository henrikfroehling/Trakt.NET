namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedShowSeasonJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedShowSeason>
    {
        public ITraktObjectJsonReader<ITraktWatchedShowSeason> CreateObjectReader() => new TraktWatchedShowSeasonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedShowSeason> CreateArrayReader() => new TraktWatchedShowSeasonArrayJsonReader();
    }
}
