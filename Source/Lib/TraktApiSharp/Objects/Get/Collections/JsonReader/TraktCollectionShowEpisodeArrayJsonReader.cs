namespace TraktApiSharp.Objects.Get.Collections.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCollectionShowEpisodeArrayJsonReader : IArrayJsonReader<ITraktCollectionShowEpisode>
    {
        public Task<IEnumerable<ITraktCollectionShowEpisode>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCollectionShowEpisode>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCollectionShowEpisode>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowEpisodeObjectReader = new TraktCollectionShowEpisodeObjectJsonReader();
                //var collectionShowEpisodeReadingTasks = new List<Task<ITraktCollectionShowEpisode>>();
                var collectionShowEpisodes = new List<ITraktCollectionShowEpisode>();

                //collectionShowEpisodeReadingTasks.Add(collectionShowEpisodeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShowEpisode collectionShowEpisode = await collectionShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShowEpisode != null)
                {
                    collectionShowEpisodes.Add(collectionShowEpisode);
                    //collectionShowEpisodeReadingTasks.Add(collectionShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionShowEpisode = await collectionShowEpisodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShowEpisodes = await Task.WhenAll(collectionShowEpisodeReadingTasks);
                //return (IEnumerable<ITraktCollectionShowEpisode>)readCollectionShowEpisodes.GetEnumerator();
                return collectionShowEpisodes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShowEpisode>));
        }
    }
}
