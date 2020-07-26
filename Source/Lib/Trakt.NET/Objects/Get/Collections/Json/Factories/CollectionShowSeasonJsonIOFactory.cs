namespace TraktNet.Objects.Get.Collections.Json.Factories
{
    using Get.Collections.Json.Reader;
    using Get.Collections.Json.Writer;
    using Objects.Json;

    internal class CollectionShowSeasonJsonIOFactory : IJsonIOFactory<ITraktCollectionShowSeason>
    {
        public IObjectJsonReader<ITraktCollectionShowSeason> CreateObjectReader() => new CollectionShowSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktCollectionShowSeason> CreateObjectWriter() => new CollectionShowSeasonObjectJsonWriter();
    }
}
