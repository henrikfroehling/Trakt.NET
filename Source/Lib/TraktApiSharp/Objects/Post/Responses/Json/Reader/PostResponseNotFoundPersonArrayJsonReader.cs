namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
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
                //var postResponseNotFoundPersonReadingTasks = new List<Task<ITraktPostResponseNotFoundPerson>>();
                var postResponseNotFoundPersons = new List<ITraktPostResponseNotFoundPerson>();

                //postResponseNotFoundPersonReadingTasks.Add(postResponseNotFoundPersonReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPostResponseNotFoundPerson postResponseNotFoundPerson = await postResponseNotFoundPersonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (postResponseNotFoundPerson != null)
                {
                    postResponseNotFoundPersons.Add(postResponseNotFoundPerson);
                    //postResponseNotFoundPersonReadingTasks.Add(postResponseNotFoundPersonObjectReader.ReadObjectAsync(jsonReader, cancellationToken));
                    postResponseNotFoundPerson = await postResponseNotFoundPersonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readPostResponseNotFoundPersons = await Task.WhenAll(postResponseNotFoundPersonReadingTasks);
                //return (IEnumerable<ITraktPostResponseNotFoundPerson>)readPostResponseNotFoundPersons.GetEnumerator();
                return postResponseNotFoundPersons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));
        }
    }
}
