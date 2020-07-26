namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCollectionProgressArrayJsonReader : ArrayJsonReader<ITraktShowCollectionProgress>
    {
        public override async Task<IEnumerable<ITraktShowCollectionProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCollectionProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCollectionProgressReader = new ShowCollectionProgressObjectJsonReader();
                var showCollectionProgresses = new List<ITraktShowCollectionProgress>();
                ITraktShowCollectionProgress showCollectionProgress = await showCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCollectionProgress != null)
                {
                    showCollectionProgresses.Add(showCollectionProgress);
                    showCollectionProgress = await showCollectionProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCollectionProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCollectionProgress>));
        }
    }
}
