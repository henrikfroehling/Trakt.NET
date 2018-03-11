namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLikeItemArrayJsonReader : AArrayJsonReader<ITraktUserLikeItem>
    {
        public override async Task<IEnumerable<ITraktUserLikeItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userLikeItemReader = new UserLikeItemObjectJsonReader();
                //var userLikeItemReadingTasks = new List<Task<ITraktUserLikeItem>>();
                var userLikeItems = new List<ITraktUserLikeItem>();

                //userLikeItemReadingTasks.Add(userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktUserLikeItem userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userLikeItem != null)
                {
                    userLikeItems.Add(userLikeItem);
                    //userLikeItemReadingTasks.Add(userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    userLikeItem = await userLikeItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readUserLikeItems = await Task.WhenAll(userLikeItemReadingTasks);
                //return (IEnumerable<ITraktUserLikeItem>)readUserLikeItems.GetEnumerator();
                return userLikeItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserLikeItem>));
        }
    }
}
