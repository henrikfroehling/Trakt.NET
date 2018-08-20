namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastAndCrewArrayJsonReader : AArrayJsonReader<ITraktCastAndCrew>
    {
        public override async Task<IEnumerable<ITraktCastAndCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCastAndCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var castAndCrewReader = new CastAndCrewObjectJsonReader();
                var castAndCrews = new List<ITraktCastAndCrew>();
                ITraktCastAndCrew castAndCrew = await castAndCrewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (castAndCrew != null)
                {
                    castAndCrews.Add(castAndCrew);
                    castAndCrew = await castAndCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return castAndCrews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCastAndCrew>));
        }
    }
}
