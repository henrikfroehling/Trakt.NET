namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCrewArrayJsonReader : ArrayJsonReader<ITraktShowCrew>
    {
        public override async Task<IEnumerable<ITraktShowCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCrewReader = new ShowCrewObjectJsonReader();
                var showCrews = new List<ITraktShowCrew>();
                ITraktShowCrew showCrew = await showCrewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCrew != null)
                {
                    showCrews.Add(showCrew);
                    showCrew = await showCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCrews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCrew>));
        }
    }
}
