namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionShowSeasonJsonReaderFactory : IJsonIOFactory<ITraktCollectionShowSeason>
    {
        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new CollectionShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowSeason> CreateArrayReader() => new CollectionShowSeasonArrayJsonReader();

        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCollectionShowSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
