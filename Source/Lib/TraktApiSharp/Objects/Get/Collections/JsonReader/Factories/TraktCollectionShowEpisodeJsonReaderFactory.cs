namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCollectionShowEpisodeJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShowEpisode>
    {
        public ITraktObjectJsonReader<ITraktCollectionShowEpisode> CreateObjectReader() => new TraktCollectionShowEpisodeObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCollectionShowEpisode> CreateArrayReader() => new TraktCollectionShowEpisodeArrayJsonReader();
    }
}
