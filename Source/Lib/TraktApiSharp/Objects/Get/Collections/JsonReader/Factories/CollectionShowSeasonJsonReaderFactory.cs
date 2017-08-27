namespace TraktApiSharp.Objects.Get.Collections.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CollectionShowSeasonJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShowSeason>
    {
        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new CollectionShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowSeason> CreateArrayReader() => new CollectionShowSeasonArrayJsonReader();
    }
}
