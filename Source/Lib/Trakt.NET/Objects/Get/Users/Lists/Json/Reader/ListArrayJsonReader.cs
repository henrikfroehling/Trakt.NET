namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListArrayJsonReader : AArrayJsonReader<ITraktList>
    {
        public override async Task<IEnumerable<ITraktList>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktList>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listReader = new ListObjectJsonReader();
                //var listReadingTasks = new List<Task<ITraktList>>();
                var lists = new List<ITraktList>();

                //listReadingTasks.Add(listReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktList list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (list != null)
                {
                    lists.Add(list);
                    //listReadingTasks.Add(listReader.ReadObjectAsync(jsonReader, cancellationToken));
                    list = await listReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readLists = await Task.WhenAll(listReadingTasks);
                //return (IEnumerable<ITraktList>)readLists.GetEnumerator();
                return lists;
            }

            return await Task.FromResult(default(IEnumerable<ITraktList>));
        }
    }
}
