namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCastMemberArrayJsonReader : AArrayJsonReader<ITraktShowCastMember>
    {
        public override async Task<IEnumerable<ITraktShowCastMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCastMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCastMemberReader = new ShowCastMemberObjectJsonReader();
                var showCastMembers = new List<ITraktShowCastMember>();
                ITraktShowCastMember showCastMember = await showCastMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCastMember != null)
                {
                    showCastMembers.Add(showCastMember);
                    showCastMember = await showCastMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCastMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCastMember>));
        }
    }
}
