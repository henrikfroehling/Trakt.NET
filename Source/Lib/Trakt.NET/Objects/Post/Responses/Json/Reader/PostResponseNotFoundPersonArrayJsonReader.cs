namespace TraktNet.Objects.Post.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundPersonArrayJsonReader : AArrayJsonReader<ITraktPostResponseNotFoundPerson>
    {
        public override async Task<IEnumerable<ITraktPostResponseNotFoundPerson>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundPersonObjectReader = new PostResponseNotFoundPersonObjectJsonReader();
                var postResponseNotFoundPersons = new List<ITraktPostResponseNotFoundPerson>();
                ITraktPostResponseNotFoundPerson postResponseNotFoundPerson = await postResponseNotFoundPersonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundPerson != null)
                {
                    postResponseNotFoundPersons.Add(postResponseNotFoundPerson);
                    postResponseNotFoundPerson = await postResponseNotFoundPersonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return postResponseNotFoundPersons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));
        }
    }
}
