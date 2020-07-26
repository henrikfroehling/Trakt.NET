namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentLikeArrayJsonReader : ArrayJsonReader<ITraktCommentLike>
    {
        public override async Task<IEnumerable<ITraktCommentLike>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentLike>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentLikeReader = new CommentLikeObjectJsonReader();
                var commentLikes = new List<ITraktCommentLike>();
                ITraktCommentLike commentLike = await commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentLike != null)
                {
                    commentLikes.Add(commentLike);
                    commentLike = await commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return commentLikes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentLike>));
        }
    }
}
