namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowArrayJsonReader : AArrayJsonReader<ITraktRecentlyUpdatedShow>
    {
        public override async Task<IEnumerable<ITraktRecentlyUpdatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var recentlyUpdatedShowReader = new RecentlyUpdatedShowObjectJsonReader();
                //var traktRecentlyUpdatedShowReadingTasks = new List<Task<ITraktRecentlyUpdatedShow>>();
                var traktRecentlyUpdatedShows = new List<ITraktRecentlyUpdatedShow>();

                //traktRecentlyUpdatedShowReadingTasks.Add(recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktRecentlyUpdatedShow != null)
                {
                    traktRecentlyUpdatedShows.Add(traktRecentlyUpdatedShow);
                    //traktRecentlyUpdatedShowReadingTasks.Add(recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktRecentlyUpdatedShow = await recentlyUpdatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readRecentlyUpdatedShows = await Task.WhenAll(traktRecentlyUpdatedShowReadingTasks);
                //return (IEnumerable<ITraktRecentlyUpdatedShow>)readRecentlyUpdatedShows.GetEnumerator();
                return traktRecentlyUpdatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktRecentlyUpdatedShow>));
        }
    }
}
