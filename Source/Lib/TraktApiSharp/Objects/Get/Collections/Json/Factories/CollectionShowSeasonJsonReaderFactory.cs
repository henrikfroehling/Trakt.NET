namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Objects.Json;

    internal class CollectionShowSeasonJsonReaderFactory : IJsonReaderFactory<ITraktCollectionShowSeason>
    {
        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new CollectionShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowSeason> CreateArrayReader() => new CollectionShowSeasonArrayJsonReader();
    }
}
