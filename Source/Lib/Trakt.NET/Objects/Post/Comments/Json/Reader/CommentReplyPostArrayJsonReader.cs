namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentReplyPostArrayJsonReader : ArrayJsonReader<ITraktCommentReplyPost>
    {
        public override async Task<IEnumerable<ITraktCommentReplyPost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentReplyPost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentReplyPostReader = new CommentReplyPostObjectJsonReader();
                var commentReplyPosts = new List<ITraktCommentReplyPost>();
                ITraktCommentReplyPost commentReplyPost = await commentReplyPostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentReplyPost != null)
                {
                    commentReplyPosts.Add(commentReplyPost);
                    commentReplyPost = await commentReplyPostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return commentReplyPosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentReplyPost>));
        }
    }
}
