namespace TraktNet.Objects.Post.Syncs.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseGroupArrayJsonReader : ArrayJsonReader<ITraktSyncPostResponseGroup>
    {
        public override async Task<IEnumerable<ITraktSyncPostResponseGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncPostResponseGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncPostResponseGroupReader = new SyncPostResponseGroupObjectJsonReader();
                var syncPostResponseGroups = new List<ITraktSyncPostResponseGroup>();
                ITraktSyncPostResponseGroup syncPostResponseGroup = await syncPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncPostResponseGroup != null)
                {
                    syncPostResponseGroups.Add(syncPostResponseGroup);
                    syncPostResponseGroup = await syncPostResponseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncPostResponseGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncPostResponseGroup>));
        }
    }
}
