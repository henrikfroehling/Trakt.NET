namespace TraktNet.Objects.Get.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingsItemArrayJsonReader : ArrayJsonReader<ITraktRatingsItem>
    {
        public override async Task<IEnumerable<ITraktRatingsItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRatingsItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var ratingsItemReader = new RatingsItemObjectJsonReader();
                var ratingsItems = new List<ITraktRatingsItem>();
                ITraktRatingsItem ratingsItem = await ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (ratingsItem != null)
                {
                    ratingsItems.Add(ratingsItem);
                    ratingsItem = await ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return ratingsItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRatingsItem>));
        }
    }
}
