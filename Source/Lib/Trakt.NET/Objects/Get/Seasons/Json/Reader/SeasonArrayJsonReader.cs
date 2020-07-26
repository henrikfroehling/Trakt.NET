namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonArrayJsonReader : ArrayJsonReader<ITraktSeason>
    {
        public override async Task<IEnumerable<ITraktSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonReader = new SeasonObjectJsonReader();
                var traktSeasons = new List<ITraktSeason>();
                ITraktSeason traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktSeason != null)
                {
                    traktSeasons.Add(traktSeason);
                    traktSeason = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeason>));
        }
    }
}
