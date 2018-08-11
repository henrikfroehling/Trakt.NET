namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowWatchedProgressArrayJsonReader : AArrayJsonReader<ITraktShowWatchedProgress>
    {
        public override async Task<IEnumerable<ITraktShowWatchedProgress>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowWatchedProgress>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showWatchedProgressReader = new ShowWatchedProgressObjectJsonReader();
                var showWatchedProgresses = new List<ITraktShowWatchedProgress>();
                ITraktShowWatchedProgress showWatchedProgress = await showWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showWatchedProgress != null)
                {
                    showWatchedProgresses.Add(showWatchedProgress);
                    showWatchedProgress = await showWatchedProgressReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showWatchedProgresses;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowWatchedProgress>));
        }
    }
}
