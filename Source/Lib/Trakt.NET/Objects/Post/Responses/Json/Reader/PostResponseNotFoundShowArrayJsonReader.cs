namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundShowArrayJsonReader : ArrayJsonReader<ITraktPostResponseNotFoundShow>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundShowObjectReader = new PostResponseNotFoundShowObjectJsonReader();
                var postResponseNotFoundShows = new List<ITraktPostResponseNotFoundShow>();
                ITraktPostResponseNotFoundShow postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundShow != null)
                {
                    postResponseNotFoundShows.Add(postResponseNotFoundShow);
                    postResponseNotFoundShow = await postResponseNotFoundShowObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return postResponseNotFoundShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundShow>));
        }
    }
}
