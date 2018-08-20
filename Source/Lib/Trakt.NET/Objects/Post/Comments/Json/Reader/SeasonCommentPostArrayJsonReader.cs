namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCommentPostArrayJsonReader : AArrayJsonReader<ITraktSeasonCommentPost>
    {
        public override async Task<IEnumerable<ITraktSeasonCommentPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSeasonCommentPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var seasonCommentPostReader = new SeasonCommentPostObjectJsonReader();
                var seasonCommentPosts = new List<ITraktSeasonCommentPost>();
                ITraktSeasonCommentPost seasonCommentPost = await seasonCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (seasonCommentPost != null)
                {
                    seasonCommentPosts.Add(seasonCommentPost);
                    seasonCommentPost = await seasonCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return seasonCommentPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSeasonCommentPost>));
        }
    }
}
