namespace TraktApiSharp.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Objects.Json;

    internal class CollectionShowSeasonJsonIOFactory : IJsonIOFactory<ITraktCollectionShowSeason>
    {
        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new CollectionShowSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktCollectionShowSeason> CreateArrayReader() => new CollectionShowSeasonArrayJsonReader();

        public IObjectJsonWriter<ITraktCollectionShowSeason> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktCollectionShowSeason> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
