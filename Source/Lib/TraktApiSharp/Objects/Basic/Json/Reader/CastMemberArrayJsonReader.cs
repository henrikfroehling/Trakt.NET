namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastMemberArrayJsonReader : IArrayJsonReader<ITraktCastMember>
    {
        public Task<IEnumerable<ITraktCastMember>> ReadArrayAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCastMember>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCastMember>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCastMember>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCastMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCastMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var castMemberReader = new CastMemberObjectJsonReader();
                //var castMemberReadingTasks = new List<Task<ITraktCastMember>>();
                var castMembers = new List<ITraktCastMember>();

                //castMemberReadingTasks.Add(castMemberReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCastMember castMember = await castMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (castMember != null)
                {
                    castMembers.Add(castMember);
                    //castMemberReadingTasks.Add(castMemberReader.ReadObjectAsync(jsonReader, cancellationToken));
                    castMember = await castMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCastMembers = await Task.WhenAll(castMemberReadingTasks);
                //return (IEnumerable<ITraktCastMember>)readCastMembers.GetEnumerator();
                return castMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCastMember>));
        }
    }
}
