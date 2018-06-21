namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentLikeArrayJsonReader : AArrayJsonReader<ITraktCommentLike>
    {
        public override async Task<IEnumerable<ITraktCommentLike>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentLike>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentLikeReader = new CommentLikeObjectJsonReader();
                //var commentLikeReadingTasks = new List<Task<ITraktCommentLike>>();
                var commentLikes = new List<ITraktCommentLike>();

                //commentLikeReadingTasks.Add(commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCommentLike commentLike = await commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentLike != null)
                {
                    commentLikes.Add(commentLike);
                    //commentLikeReadingTasks.Add(commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken));
                    commentLike = await commentLikeReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCommentLikes = await Task.WhenAll(commentLikeReadingTasks);
                //return (IEnumerable<ITraktCommentLike>)readCommentLikes.GetEnumerator();
                return commentLikes;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentLike>));
        }
    }
}
