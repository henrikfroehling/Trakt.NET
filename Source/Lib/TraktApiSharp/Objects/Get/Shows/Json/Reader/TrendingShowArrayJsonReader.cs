namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
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
                //var traktTrendingShowReadingTasks = new List<Task<ITraktTrendingShow>>();
                var traktTrendingShows = new List<ITraktTrendingShow>();

                //traktTrendingShowReadingTasks.Add(trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktTrendingShow traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktTrendingShow != null)
                {
                    traktTrendingShows.Add(traktTrendingShow);
                    //traktTrendingShowReadingTasks.Add(trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktTrendingShow = await trendingShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readTrendingShows = await Task.WhenAll(traktTrendingShowReadingTasks);
                //return (IEnumerable<ITraktTrendingShow>)readTrendingShows.GetEnumerator();
                return traktTrendingShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktTrendingShow>));
        }
    }
}
