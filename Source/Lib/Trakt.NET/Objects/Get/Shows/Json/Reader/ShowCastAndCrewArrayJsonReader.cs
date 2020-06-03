namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCastAndCrewArrayJsonReader : AArrayJsonReader<ITraktShowCastAndCrew>
    {
        public override async Task<IEnumerable<ITraktShowCastAndCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowCastAndCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var showCastAndCrewReader = new ShowCastAndCrewObjectJsonReader();
                var showCastAndCrews = new List<ITraktShowCastAndCrew>();
                ITraktShowCastAndCrew showCastAndCrew = await showCastAndCrewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (showCastAndCrew != null)
                {
                    showCastAndCrews.Add(showCastAndCrew);
                    showCastAndCrew = await showCastAndCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return showCastAndCrews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowCastAndCrew>));
        }
    }
}
