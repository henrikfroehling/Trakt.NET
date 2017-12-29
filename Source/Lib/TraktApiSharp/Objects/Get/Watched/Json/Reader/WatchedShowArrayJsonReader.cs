namespace TraktApiSharp.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowArrayJsonReader : AArrayJsonReader<ITraktWatchedShow>
    {
        public override async Task<IEnumerable<ITraktWatchedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktWatchedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var watchedShowReader = new WatchedShowObjectJsonReader();
                //var watchedShowReadingTasks = new List<Task<ITraktWatchedShow>>();
                var watchedShows = new List<ITraktWatchedShow>();

                //watchedShowReadingTasks.Add(watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktWatchedShow watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShow != null)
                {
                    watchedShows.Add(watchedShow);
                    //watchedShowReadingTasks.Add(watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken));
                    watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readWatchedShows = await Task.WhenAll(watchedShowReadingTasks);
                //return (IEnumerable<ITraktWatchedShow>)readWatchedShows.GetEnumerator();
                return watchedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShow>));
        }
    }
}
