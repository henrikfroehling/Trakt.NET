namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCollectionShowEpisodeJsonReaderFactory : ITraktJsonReaderFactory<ITraktCollectionShowEpisode>
    {
        public ITraktObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectReader() => new TraktCollectionShowEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionShowEpisode> CreateArrayReader() => new TraktCollectionShowEpisodeArrayJsonReader();
    }
}
