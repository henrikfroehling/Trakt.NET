namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktShowAliasArrayJsonReader : IArrayJsonReader<ITraktShowAlias>
    {
        public Task<IEnumerable<ITraktShowAlias>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktShowAlias>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktShowAlias>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktShowAlias>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktShowAlias>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowAlias>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieAliasReader = new TraktShowAliasObjectJsonReader();
                //var traktShowAliasReadingTasks = new List<Task<ITraktShowAlias>>();
                var traktShowAliass = new List<ITraktShowAlias>();

                //traktShowAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktShowAlias traktShowAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShowAlias != null)
                {
                    traktShowAliass.Add(traktShowAlias);
                    //traktShowAliasReadingTasks.Add(movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken));
                    traktShowAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readShowAliass = await Task.WhenAll(traktShowAliasReadingTasks);
                //return (IEnumerable<ITraktShowAlias>)readShowAliass.GetEnumerator();
                return traktShowAliass;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowAlias>));
        }
    }
}
