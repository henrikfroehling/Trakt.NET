namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastMemberArrayJsonReader : AArrayJsonReader<ITraktCastMember>
    {
        public override async Task<IEnumerable<ITraktCastMember>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
