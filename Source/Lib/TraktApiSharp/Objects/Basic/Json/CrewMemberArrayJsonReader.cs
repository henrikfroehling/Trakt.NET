namespace TraktApiSharp.Objects.Basic.Json
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberArrayJsonReader : IArrayJsonReader<ITraktCrewMember>
    {
        public Task<IEnumerable<ITraktCrewMember>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktCrewMember>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktCrewMember>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktCrewMember>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktCrewMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCrewMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var crewMemberReader = new CrewMemberObjectJsonReader();
                //var crewMemberReadingTasks = new List<Task<ITraktCrewMember>>();
                var crewMembers = new List<ITraktCrewMember>();

                //crewMemberReadingTasks.Add(crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktCrewMember crewMember = await crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (crewMember != null)
                {
                    crewMembers.Add(crewMember);
                    //crewMemberReadingTasks.Add(crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken));
                    crewMember = await crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCrewMembers = await Task.WhenAll(crewMemberReadingTasks);
                //return (IEnumerable<ITraktCrewMember>)readCrewMembers.GetEnumerator();
                return crewMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCrewMember>));
        }
    }
}
