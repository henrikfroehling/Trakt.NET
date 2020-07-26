namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAirsArrayJsonReader : ArrayJsonReader<ITraktShowAirs>
    {
        public override async Task<IEnumerable<ITraktShowAirs>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowAirs>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showAirsReader = new ShowAirsObjectJsonReader();
                var showAirss = new List<ITraktShowAirs>();
                ITraktShowAirs showAirs = await showAirsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showAirs != null)
                {
                    showAirss.Add(showAirs);
                    showAirs = await showAirsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showAirss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowAirs>));
        }
    }
}
