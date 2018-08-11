namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RatingArrayJsonReader : AArrayJsonReader<ITraktRating>
    {
        public override async Task<IEnumerable<ITraktRating>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRating>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var ratingReader = new RatingObjectJsonReader();
                var ratings = new List<ITraktRating>();
                ITraktRating rating = await ratingReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (rating != null)
                {
                    ratings.Add(rating);
                    rating = await ratingReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return ratings;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRating>));
        }
    }
}
