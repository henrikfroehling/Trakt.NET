namespace TraktNet.Objects.Post.Syncs.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncPostResponseNotFoundGroupArrayJsonReader : ArrayJsonReader<ITraktSyncPostResponseNotFoundGroup>
    {
        public override async Task<IEnumerable<ITraktSyncPostResponseNotFoundGroup>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSyncPostResponseNotFoundGroup>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var syncPostResponseNotFoundGroupReader = new SyncPostResponseNotFoundGroupObjectJsonReader();
                var syncPostResponseNotFoundGroups = new List<ITraktSyncPostResponseNotFoundGroup>();
                ITraktSyncPostResponseNotFoundGroup syncPostResponseNotFoundGroup = await syncPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (syncPostResponseNotFoundGroup != null)
                {
                    syncPostResponseNotFoundGroups.Add(syncPostResponseNotFoundGroup);
                    syncPostResponseNotFoundGroup = await syncPostResponseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return syncPostResponseNotFoundGroups;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSyncPostResponseNotFoundGroup>));
        }
    }
}
