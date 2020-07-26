namespace TraktNet.Objects.Get.Watchlist.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchlistItemArrayJsonReader : ArrayJsonReader<ITraktWatchlistItem>
    {
        public override async Task<IEnumerable<ITraktWatchlistItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchlistItemReader = new WatchlistItemObjectJsonReader();
                var watchlistItems = new List<ITraktWatchlistItem>();
                ITraktWatchlistItem watchlistItem = await watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchlistItem != null)
                {
                    watchlistItems.Add(watchlistItem);
                    watchlistItem = await watchlistItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return watchlistItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchlistItem>));
        }
    }
}
