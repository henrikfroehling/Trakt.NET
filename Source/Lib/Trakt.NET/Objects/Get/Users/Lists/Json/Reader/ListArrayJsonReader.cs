namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListArrayJsonReader : ArrayJsonReader<ITraktList>
    {
        public override async Task<IEnumerable<ITraktList>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktList>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listReader = new ListObjectJsonReader();
                var lists = new List<ITraktList>();
                ITraktList list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (list != null)
                {
                    lists.Add(list);
                    list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return lists;
            }

            return await Task.FromResult(default(IEnumerable<ITraktList>));
        }
    }
}
