namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedShowArrayJsonReader : ArrayJsonReader<ITraktMostAnticipatedShow>
    {
        public override async Task<IEnumerable<ITraktMostAnticipatedShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostAnticipatedShowReader = new MostAnticipatedShowObjectJsonReader();
                var traktMostAnticipatedShows = new List<ITraktMostAnticipatedShow>();
                ITraktMostAnticipatedShow traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostAnticipatedShow != null)
                {
                    traktMostAnticipatedShows.Add(traktMostAnticipatedShow);
                    traktMostAnticipatedShow = await mostAnticipatedShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMostAnticipatedShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostAnticipatedShow>));
        }
    }
}
