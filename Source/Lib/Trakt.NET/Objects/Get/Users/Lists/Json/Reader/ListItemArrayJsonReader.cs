namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemArrayJsonReader : AArrayJsonReader<ITraktListItem>
    {
        public override async Task<IEnumerable<ITraktListItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktListItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listItemReader = new ListItemObjectJsonReader();
                var listItems = new List<ITraktListItem>();
                ITraktListItem listItem = await listItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (listItem != null)
                {
                    listItems.Add(listItem);
                    listItem = await listItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return listItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktListItem>));
        }
    }
}
