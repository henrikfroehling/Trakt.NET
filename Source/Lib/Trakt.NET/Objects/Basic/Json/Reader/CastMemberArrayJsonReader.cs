namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastMemberArrayJsonReader : ArrayJsonReader<ITraktCastMember>
    {
        public override async Task<IEnumerable<ITraktCastMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCastMember>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var castMemberReader = new CastMemberObjectJsonReader();
                var castMembers = new List<ITraktCastMember>();
                ITraktCastMember castMember = await castMemberReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (castMember != null)
                {
                    castMembers.Add(castMember);
                    castMember = await castMemberReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return castMembers;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCastMember>));
        }
    }
}
