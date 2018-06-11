namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentItemArrayJsonReader : AArrayJsonReader<ITraktCommentItem>
    {
        public override async Task<IEnumerable<ITraktCommentItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentItemReader = new CommentItemObjectJsonReader();
                //var commentItemReadingTasks = new List<Task<ITraktCommentItem>>();
                var commentItems = new List<ITraktCommentItem>();

                //commentItemReadingTasks.Add(commentItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCommentItem commentItem = await commentItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentItem != null)
                {
                    commentItems.Add(commentItem);
                    //commentItemReadingTasks.Add(commentItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    commentItem = await commentItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCommentItems = await Task.WhenAll(commentItemReadingTasks);
                //return (IEnumerable<ITraktCommentItem>)readCommentItems.GetEnumerator();
                return commentItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentItem>));
        }
    }
}
