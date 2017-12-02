namespace TraktApiSharp.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowArrayJsonReader : IArrayJsonReader<ITraktCollectionShow>
    {
        public Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCollectionShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowReader = new CollectionShowObjectJsonReader();
                //var collectionShowReadingTasks = new List<Task<ITraktCollectionShow>>();
                var collectionShows = new List<ITraktCollectionShow>();

                //collectionShowReadingTasks.Add(collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShow collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShow != null)
                {
                    collectionShows.Add(collectionShow);
                    //collectionShowReadingTasks.Add(collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionShow = await collectionShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShows = await Task.WhenAll(collectionShowReadingTasks);
                //return (IEnumerable<ITraktCollectionShow>)readCollectionShows.GetEnumerator();
                return collectionShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShow>));
        }
    }
}
