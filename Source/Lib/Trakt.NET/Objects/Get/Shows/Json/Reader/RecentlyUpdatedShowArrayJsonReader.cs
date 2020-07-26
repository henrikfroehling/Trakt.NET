namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowArrayJsonReader : ArrayJsonReader<ITraktRecentlyUpdatedShow>
    {
        public override async Task<IEnumerable<ITraktRecentlyUpdatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var recentlyUpdatedShowReader = new RecentlyUpdatedShowObjectJsonReader();
                var traktRecentlyUpdatedShows = new List<ITraktRecentlyUpdatedShow>();
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktRecentlyUpdatedShow != null)
                {
                    traktRecentlyUpdatedShows.Add(traktRecentlyUpdatedShow);
                    traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktRecentlyUpdatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));
        }
    }
}
