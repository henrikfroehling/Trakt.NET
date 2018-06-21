namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundSeasonArrayJsonReader : AArrayJsonReader<ITraktPostResponseNotFoundSeason>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundSeason>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundSeasonObjectReader = new PostResponseNotFoundSeasonObjectJsonReader();
                //var postResponseNotFoundSeasonReadingTasks = new List<Task<ITraktPostResponseNotFoundSeason>>();
                var postResponseNotFoundSeasons = new List<ITraktPostResponseNotFoundSeason>();

                //postResponseNotFoundSeasonReadingTasks.Add(postResponseNotFoundSeasonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundSeason postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundSeason != null)
                {
                    postResponseNotFoundSeasons.Add(postResponseNotFoundSeason);
                    //postResponseNotFoundSeasonReadingTasks.Add(postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundSeason = await postResponseNotFoundSeasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundSeasons = await Task.WhenAll(postResponseNotFoundSeasonReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundSeason>)readPostResponseNotFoundSeasons.GetEnumerator();
                return postResponseNotFoundSeasons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundSeason>));
        }
    }
}
