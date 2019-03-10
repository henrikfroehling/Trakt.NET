namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowArrayJsonReader : AArrayJsonReader<ITraktCollectionShow>
    {
        public override async Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowReader = new CollectionShowObjectJsonReader();
                var collectionShows = new List<ITraktCollectionShow>();
                ITraktCollectionShow collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShow != null)
                {
                    collectionShows.Add(collectionShow);
                    collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return collectionShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));
        }
    }
}
