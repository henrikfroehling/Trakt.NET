namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentItemArrayJsonReader : ArrayJsonReader<ITraktCommentItem>
    {
        public override async Task<IEnumerable<ITraktCommentItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentItemReader = new CommentItemObjectJsonReader();
                var commentItems = new List<ITraktCommentItem>();

                ITraktCommentItem commentItem = await commentItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentItem != null)
                {
                    commentItems.Add(commentItem);
                    commentItem = await commentItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return commentItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentItem>));
        }
    }
}
