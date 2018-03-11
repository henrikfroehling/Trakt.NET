namespace TraktApiSharp.Objects.Get.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchlistItemArrayJsonReader : AArrayJsonReader<ITraktWatchlistItem>
    {
        public override async Task<IEnumerable<ITraktWatchlistItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchlistItemReader = new WatchlistItemObjectJsonReader();
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
