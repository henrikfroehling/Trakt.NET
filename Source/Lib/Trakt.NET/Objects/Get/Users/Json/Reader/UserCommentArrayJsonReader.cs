namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCommentArrayJsonReader : AArrayJsonReader<ITraktUserComment>
    {
        public override async Task<IEnumerable<ITraktUserComment>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserComment>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userCommentReader = new UserCommentObjectJsonReader();
                var userComments = new List<ITraktUserComment>();
                ITraktUserComment userComment = await userCommentReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userComment != null)
                {
                    userComments.Add(userComment);
                    userComment = await userCommentReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userComments;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserComment>));
        }
    }
}
