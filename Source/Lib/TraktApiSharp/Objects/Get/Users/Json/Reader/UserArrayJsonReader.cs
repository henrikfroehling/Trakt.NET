namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserArrayJsonReader : AArrayJsonReader<ITraktUser>
    {
        public override async Task<IEnumerable<ITraktUser>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUser>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userReader = new UserObjectJsonReader();
                //var userReadingTasks = new List<Task<ITraktUser>>();
                var users = new List<ITraktUser>();

                //userReadingTasks.Add(userReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUser user = await userReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (user != null)
                {
                    users.Add(user);
                    //userReadingTasks.Add(userReader.ReadObjectAsync(jsonReader, cancellationToken));
                    user = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUsers = await Task.WhenAll(userReadingTasks);
                //return (IEnumerable<ITraktUser>)readUsers.GetEnumerator();
                return users;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUser>));
        }
    }
}
