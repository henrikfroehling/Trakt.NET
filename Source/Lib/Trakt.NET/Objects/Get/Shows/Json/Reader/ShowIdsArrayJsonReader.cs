namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowIdsArrayJsonReader : ArrayJsonReader<ITraktShowIds>
    {
        public override async Task<IEnumerable<ITraktShowIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showIdsReader = new ShowIdsObjectJsonReader();
                var showIdss = new List<ITraktShowIds>();
                ITraktShowIds showIds = await showIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showIds != null)
                {
                    showIdss.Add(showIds);
                    showIds = await showIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowIds>));
        }
    }
}
