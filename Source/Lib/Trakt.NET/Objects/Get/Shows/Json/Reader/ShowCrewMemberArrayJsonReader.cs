namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCrewMemberArrayJsonReader : ArrayJsonReader<ITraktShowCrewMember>
    {
        public override async Task<IEnumerable<ITraktShowCrewMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCrewMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCrewMemberReader = new ShowCrewMemberObjectJsonReader();
                var showCrewMembers = new List<ITraktShowCrewMember>();
                ITraktShowCrewMember showCrewMember = await showCrewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCrewMember != null)
                {
                    showCrewMembers.Add(showCrewMember);
                    showCrewMember = await showCrewMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCrewMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCrewMember>));
        }
    }
}
