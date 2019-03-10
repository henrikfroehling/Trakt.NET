namespace TraktNet.Objects.Get.Watched.Json.Reader
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
                var watchedShows = new List<ITraktWatchedShow>();
                ITraktWatchedShow watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (watchedShow != null)
                {
                    watchedShows.Add(watchedShow);
                    watchedShow = await watchedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return watchedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktWatchedShow>));
        }
    }
}
