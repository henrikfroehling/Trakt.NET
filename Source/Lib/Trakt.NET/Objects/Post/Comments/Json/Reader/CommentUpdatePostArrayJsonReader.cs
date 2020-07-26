namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentUpdatePostArrayJsonReader : ArrayJsonReader<ITraktCommentUpdatePost>
    {
        public override async Task<IEnumerable<ITraktCommentUpdatePost>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentUpdatePost>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentUpdatePostReader = new CommentUpdatePostObjectJsonReader();
                var commentUpdatePosts = new List<ITraktCommentUpdatePost>();
                ITraktCommentUpdatePost commentUpdatePost = await commentUpdatePostReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentUpdatePost != null)
                {
                    commentUpdatePosts.Add(commentUpdatePost);
                    commentUpdatePost = await commentUpdatePostReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return commentUpdatePosts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentUpdatePost>));
        }
    }
}
