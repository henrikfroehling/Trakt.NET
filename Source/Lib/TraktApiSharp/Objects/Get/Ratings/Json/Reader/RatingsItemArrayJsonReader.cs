namespace TraktApiSharp.Objects.Get.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingsItemArrayJsonReader : AArrayJsonReader<ITraktRatingsItem>
    {
        public override async Task<IEnumerable<ITraktRatingsItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRatingsItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var ratingsItemReader = new RatingsItemObjectJsonReader();
                //var ratingsItemReadingTasks = new List<Task<ITraktRatingsItem>>();
                var ratingsItems = new List<ITraktRatingsItem>();

                //ratingsItemReadingTasks.Add(ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktRatingsItem ratingsItem = await ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (ratingsItem != null)
                {
                    ratingsItems.Add(ratingsItem);
                    //ratingsItemReadingTasks.Add(ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    ratingsItem = await ratingsItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readRatingsItems = await Task.WhenAll(ratingsItemReadingTasks);
                //return (IEnumerable<ITraktRatingsItem>)readRatingsItems.GetEnumerator();
                return ratingsItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRatingsItem>));
        }
    }
}
