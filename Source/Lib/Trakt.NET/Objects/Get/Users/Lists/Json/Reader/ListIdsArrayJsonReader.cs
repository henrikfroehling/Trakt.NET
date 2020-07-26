namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListIdsArrayJsonReader : ArrayJsonReader<ITraktListIds>
    {
        public override async Task<IEnumerable<ITraktListIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktListIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var listIdsReader = new ListIdsObjectJsonReader();
                var listIdss = new List<ITraktListIds>();
                ITraktListIds listIds = await listIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (listIds != null)
                {
                    listIdss.Add(listIds);
                    listIds = await listIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return listIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktListIds>));
        }
    }
}
