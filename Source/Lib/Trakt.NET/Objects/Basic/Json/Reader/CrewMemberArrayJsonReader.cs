namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberArrayJsonReader : ArrayJsonReader<ITraktCrewMember>
    {
        public override async Task<IEnumerable<ITraktCrewMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCrewMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var crewMemberReader = new CrewMemberObjectJsonReader();
                var crewMembers = new List<ITraktCrewMember>();
                ITraktCrewMember crewMember = await crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (crewMember != null)
                {
                    crewMembers.Add(crewMember);
                    crewMember = await crewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return crewMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCrewMember>));
        }
    }
}
