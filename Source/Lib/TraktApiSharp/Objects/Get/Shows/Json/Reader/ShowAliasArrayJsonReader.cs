namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
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
