namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCollectionProgressArrayJsonReader : AArrayJsonReader<ITraktSeasonCollectionProgress>
    {
        public override async Task<IEnumerable<ITraktSeasonCollectionProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCollectionProgressReader = new SeasonCollectionProgressObjectJsonReader();
                var traktSeasonCollectionProgresses = new List<ITraktSeasonCollectionProgress>();
                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = await seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeasonCollectionProgress != null)
                {
                    traktSeasonCollectionProgresses.Add(traktSeasonCollectionProgress);
                    traktSeasonCollectionProgress = await seasonCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktSeasonCollectionProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonCollectionProgress>));
        }
    }
}
