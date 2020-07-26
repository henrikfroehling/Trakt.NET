namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCommentPostArrayJsonReader : ArrayJsonReader<ITraktEpisodeCommentPost>
    {
        public override async Task<IEnumerable<ITraktEpisodeCommentPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktEpisodeCommentPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var episodeCommentPostReader = new EpisodeCommentPostObjectJsonReader();
                var episodeCommentPosts = new List<ITraktEpisodeCommentPost>();
                ITraktEpisodeCommentPost episodeCommentPost = await episodeCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (episodeCommentPost != null)
                {
                    episodeCommentPosts.Add(episodeCommentPost);
                    episodeCommentPost = await episodeCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return episodeCommentPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktEpisodeCommentPost>));
        }
    }
}
