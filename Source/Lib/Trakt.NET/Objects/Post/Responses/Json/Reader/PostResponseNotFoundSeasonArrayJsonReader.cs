namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundSeasonArrayJsonReader : ArrayJsonReader<ITraktPostResponseNotFoundSeason>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundSeasonObjectReader = new PostResponseNotFoundSeasonObjectJsonReader();
                var postResponseNotFoundSeasons = new List<ITraktPostResponseNotFoundSeason>();
                ITraktPostResponseNotFoundSeason postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundSeason != null)
                {
                    postResponseNotFoundSeasons.Add(postResponseNotFoundSeason);
                    postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return postResponseNotFoundSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));
        }
    }
}
