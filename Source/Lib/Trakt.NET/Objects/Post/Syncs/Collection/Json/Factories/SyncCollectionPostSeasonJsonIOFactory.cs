namespace TraktNet.Objects.Post.Syncs.Collection.Json.Factories
{
    using Objects.Json;
    using Reader;
    using Writer;

    internal class SyncCollectionPostSeasonJsonIOFactory : IJsonIOFactory<ITraktSyncCollectionPostSeason>
    {
        public IObjectJsonReader<ITraktSyncCollectionPostSeason> CreateObjectReader() => new SyncCollectionPostSeasonObjectJsonReader();

        public IObjectJsonWriter<ITraktSyncCollectionPostSeason> CreateObjectWriter() => new SyncCollectionPostSeasonObjectJsonWriter();
    }
}
