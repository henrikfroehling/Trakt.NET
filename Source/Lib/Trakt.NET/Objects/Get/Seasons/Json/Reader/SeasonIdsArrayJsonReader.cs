namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonIdsArrayJsonReader : AArrayJsonReader<ITraktSeasonIds>
    {
        public override async Task<IEnumerable<ITraktSeasonIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonIdsReader = new SeasonIdsObjectJsonReader();
                var seasonIdss = new List<ITraktSeasonIds>();
                ITraktSeasonIds seasonIds = await seasonIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (seasonIds != null)
                {
                    seasonIdss.Add(seasonIds);
                    seasonIds = await seasonIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return seasonIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonIds>));
        }
    }
}
