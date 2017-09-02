namespace TraktApiSharp.Objects.Get.Watchlist.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchlistItemArrayJsonReader : IArrayJsonReader<ITraktWatchlistItem>
    {
        public Task<IEnumerable<ITraktWatchlistItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktWatchlistItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktWatchlistItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchlistItemReader = new TraktWatchlistItemObjectJsonReader();
                //var watchlistItemReadingTasks = new List<Task<ITraktWatchlistItem>>();
                var watchlistItems = new List<ITraktWatchlistItem>();

                //watchlistItemReadingTasks.Add(watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchlistItem watchlistItem = await watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchlistItem != null)
                {
                    watchlistItems.Add(watchlistItem);
                    //watchlistItemReadingTasks.Add(watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchlistItem = await watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchlistItems = await Task.WhenAll(watchlistItemReadingTasks);
                //return (IEnumerable<ITraktWatchlistItem>)readWatchlistItems.GetEnumerator();
                return watchlistItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));
        }
    }
}
