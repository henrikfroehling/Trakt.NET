namespace TraktApiSharp.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonArrayJsonReader : AArrayJsonReader<ITraktSeason>
    {
        public override async Task<IEnumerable<ITraktSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonReader = new SeasonObjectJsonReader();
                //var traktSeasonReadingTasks = new List<Task<ITraktSeason>>();
                var traktSeasons = new List<ITraktSeason>();

                //traktSeasonReadingTasks.Add(seasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktSeason traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeason != null)
                {
                    traktSeasons.Add(traktSeason);
                    //traktSeasonReadingTasks.Add(seasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readSeasons = await Task.WhenAll(traktSeasonReadingTasks);
                //return (IEnumerable<ITraktSeason>)readSeasons.GetEnumerator();
                return traktSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeason>));
        }
    }
}
