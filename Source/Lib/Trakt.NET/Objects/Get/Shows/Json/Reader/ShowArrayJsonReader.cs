namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowArrayJsonReader : AArrayJsonReader<ITraktShow>
    {
        public override async Task<IEnumerable<ITraktShow>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShow>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieReader = new ShowObjectJsonReader();
                var traktShows = new List<ITraktShow>();
                ITraktShow traktShow = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShow != null)
                {
                    traktShows.Add(traktShow);
                    traktShow = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktShows;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShow>));
        }
    }
}
