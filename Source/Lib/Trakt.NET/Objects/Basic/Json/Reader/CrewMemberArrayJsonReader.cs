namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberArrayJsonReader : AArrayJsonReader<ITraktCrewMember>
    {
        public override async Task<IEnumerable<ITraktCrewMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
