namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCShowArrayJsonReader : ArrayJsonReader<ITraktMostPWCShow>
    {
        public override async Task<IEnumerable<ITraktMostPWCShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var mostPWCShowReader = new MostPWCShowObjectJsonReader();
                var traktMostPWCShows = new List<ITraktMostPWCShow>();
                ITraktMostPWCShow traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktMostPWCShow != null)
                {
                    traktMostPWCShows.Add(traktMostPWCShow);
                    traktMostPWCShow = await mostPWCShowReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktMostPWCShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktMostPWCShow>));
        }
    }
}
