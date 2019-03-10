namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CommentArrayJsonReader : AArrayJsonReader<ITraktComment>
    {
        public override async Task<IEnumerable<ITraktComment>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktComment>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var commentReader = new CommentObjectJsonReader();
                var comments = new List<ITraktComment>();
                ITraktComment comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (comment != null)
                {
                    comments.Add(comment);
                    comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return comments;
            }

            return await Task.FromResult(default(IEnumerable<ITraktComment>));
        }
    }
}
