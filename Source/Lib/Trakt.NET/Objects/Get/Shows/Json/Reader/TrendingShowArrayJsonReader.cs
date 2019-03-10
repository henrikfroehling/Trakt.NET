namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TrendingShowArrayJsonReader : AArrayJsonReader<ITraktTrendingShow>
    {
        public override async Task<IEnumerable<ITraktTrendingShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktTrendingShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var trendingShowReader = new TrendingShowObjectJsonReader();
                var traktTrendingShows = new List<ITraktTrendingShow>();
                ITraktTrendingShow traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktTrendingShow != null)
                {
                    traktTrendingShows.Add(traktTrendingShow);
                    traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktTrendingShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktTrendingShow>));
        }
    }
}
