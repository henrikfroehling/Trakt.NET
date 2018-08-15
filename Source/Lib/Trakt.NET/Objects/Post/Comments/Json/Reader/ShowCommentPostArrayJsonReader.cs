namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCommentPostArrayJsonReader : AArrayJsonReader<ITraktShowCommentPost>
    {
        public override async Task<IEnumerable<ITraktShowCommentPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCommentPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCommentPostReader = new ShowCommentPostObjectJsonReader();
                var showCommentPosts = new List<ITraktShowCommentPost>();
                ITraktShowCommentPost showCommentPost = await showCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCommentPost != null)
                {
                    showCommentPosts.Add(showCommentPost);
                    showCommentPost = await showCommentPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCommentPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCommentPost>));
        }
    }
}
