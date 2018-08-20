namespace TraktNet.Objects.Post.Comments.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentPostResponseArrayJsonReader : AArrayJsonReader<ITraktCommentPostResponse>
    {
        public override async Task<IEnumerable<ITraktCommentPostResponse>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCommentPostResponse>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentPostResponseReader = new CommentPostResponseObjectJsonReader();
                var commentPostResponses = new List<ITraktCommentPostResponse>();
                ITraktCommentPostResponse commentPostResponse = await commentPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (commentPostResponse != null)
                {
                    commentPostResponses.Add(commentPostResponse);
                    commentPostResponse = await commentPostResponseReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return commentPostResponses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCommentPostResponse>));
        }
    }
}
