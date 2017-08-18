namespace TraktApiSharp.Objects.Post.Responses.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktPostResponseNotFoundPersonArrayJsonReader : IArrayJsonReader<ITraktPostResponseNotFoundPerson>
    {
        public Task<IEnumerable<ITraktPostResponseNotFoundPerson>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPostResponseNotFoundPerson>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPostResponseNotFoundPerson>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPostResponseNotFoundPerson>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var postResponseNotFoundPersonObjectReader = new TraktPostResponseNotFoundPersonObjectJsonReader();
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
