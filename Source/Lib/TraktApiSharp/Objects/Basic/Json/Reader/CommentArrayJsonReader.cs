namespace TraktApiSharp.Objects.Basic.Json.Reader
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
                //var commentReadingTasks = new List<Task<ITraktComment>>();
                var comments = new List<ITraktComment>();

                //commentReadingTasks.Add(commentReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktComment comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (comment != null)
                {
                    comments.Add(comment);
                    //commentReadingTasks.Add(commentReader.ReadObjectAsync(jsonReader, cancellationToken));
                    comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readComments = await Task.WhenAll(commentReadingTasks);
                //return (IEnumerable<ITraktComment>)readComments.GetEnumerator();
                return comments;
            }

            return await Task.FromResult(default(IEnumerable<ITraktComment>));
        }
    }
}
