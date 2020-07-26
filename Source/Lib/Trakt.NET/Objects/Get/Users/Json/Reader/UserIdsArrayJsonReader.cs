namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserIdsArrayJsonReader : ArrayJsonReader<ITraktUserIds>
    {
        public override async Task<IEnumerable<ITraktUserIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userIdsReader = new UserIdsObjectJsonReader();
                var userIdss = new List<ITraktUserIds>();
                ITraktUserIds userIds = await userIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userIds != null)
                {
                    userIdss.Add(userIds);
                    userIds = await userIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserIds>));
        }
    }
}
