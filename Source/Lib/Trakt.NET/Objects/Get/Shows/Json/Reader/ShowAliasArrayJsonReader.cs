namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAliasArrayJsonReader : AArrayJsonReader<ITraktShowAlias>
    {
        public override async Task<IEnumerable<ITraktShowAlias>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowAlias>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieAliasReader = new ShowAliasObjectJsonReader();
                var traktShowAliass = new List<ITraktShowAlias>();
                ITraktShowAlias traktShowAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShowAlias != null)
                {
                    traktShowAliass.Add(traktShowAlias);
                    traktShowAlias = await movieAliasReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktShowAliass;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowAlias>));
        }
    }
}
