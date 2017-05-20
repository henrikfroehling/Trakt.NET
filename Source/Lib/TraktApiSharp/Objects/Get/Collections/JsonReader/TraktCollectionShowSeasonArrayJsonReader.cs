namespace TraktApiSharp.Objects.Get.Collections.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktCollectionShowSeasonArrayJsonReader : ITraktArrayJsonReader<ITraktCollectionShowSeason>
    {
        public Task<IEnumerable<ITraktCollectionShowSeason>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCollectionShowSeason>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCollectionShowSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var collectionShowSeasonObjectReader = new TraktCollectionShowSeasonObjectJsonReader();
                //var collectionShowSeasonReadingTasks = new List<Task<ITraktCollectionShowSeason>>();
                var collectionShowSeasons = new List<ITraktCollectionShowSeason>();

                //collectionShowSeasonReadingTasks.Add(collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCollectionShowSeason collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (collectionShowSeason != null)
                {
                    collectionShowSeasons.Add(collectionShowSeason);
                    //collectionShowSeasonReadingTasks.Add(collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    collectionShowSeason = await collectionShowSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCollectionShowSeasons = await Task.WhenAll(collectionShowSeasonReadingTasks);
                //return (IEnumerable<ITraktCollectionShowSeason>)readCollectionShowSeasons.GetEnumerator();
                return collectionShowSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCollectionShowSeason>));
        }
    }
}
