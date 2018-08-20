namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class IdsArrayJsonReader : AArrayJsonReader<ITraktIds>
    {
        public override async Task<IEnumerable<ITraktIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var idsReader = new IdsObjectJsonReader();
                var idss = new List<ITraktIds>();
                ITraktIds ids = await idsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (ids != null)
                {
                    idss.Add(ids);
                    ids = await idsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return idss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktIds>));
        }
    }
}
