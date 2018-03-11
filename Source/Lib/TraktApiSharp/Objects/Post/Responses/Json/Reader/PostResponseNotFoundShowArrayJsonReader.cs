namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundShowArrayJsonReader : AArrayJsonReader<ITraktPostResponseNotFoundShow>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundShowObjectReader = new PostResponseNotFoundShowObjectJsonReader();
                //var postResponseNotFoundShowReadingTasks = new List<Task<ITraktPostResponseNotFoundShow>>();
                var postResponseNotFoundShows = new List<ITraktPostResponseNotFoundShow>();

                //postResponseNotFoundShowReadingTasks.Add(postResponseNotFoundShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundShow postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundShow != null)
                {
                    postResponseNotFoundShows.Add(postResponseNotFoundShow);
                    //postResponseNotFoundShowReadingTasks.Add(postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundShows = await Task.WhenAll(postResponseNotFoundShowReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundShow>)readPostResponseNotFoundShows.GetEnumerator();
                return postResponseNotFoundShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));
        }
    }
}
