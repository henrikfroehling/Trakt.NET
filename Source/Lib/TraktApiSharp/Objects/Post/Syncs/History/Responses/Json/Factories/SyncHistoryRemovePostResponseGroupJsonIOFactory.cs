namespace TraktApiSharp.Objects.Post.Syncs.History.Responses.Json.Factories
{
    using Objects.Json;
    using Post.Syncs.History.Responses.Json.Reader;
    using System;

    internal class SyncHistoryRemovePostResponseGroupJsonIOFactory : IJsonIOFactory<ITraktSyncHistoryRemovePostResponseGroup>
    {
        public IObjectJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectReader() => new SyncHistoryRemovePostResponseGroupObjectJsonReader();

        public IArrayJsonReader<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktSyncHistoryRemovePostResponseGroup)} is not supported.");
        }

        public IObjectJsonWriter<ITraktSyncHistoryRemovePostResponseGroup> CreateObjectWriter()
        {
            throw new NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSyncHistoryRemovePostResponseGroup> CreateArrayWriter()
        {
            throw new NotImplementedException();
        }
    }
}
