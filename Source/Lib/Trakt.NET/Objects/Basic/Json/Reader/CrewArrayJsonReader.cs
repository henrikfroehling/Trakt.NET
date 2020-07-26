namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewArrayJsonReader : ArrayJsonReader<ITraktCrew>
    {
        public override async Task<IEnumerable<ITraktCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var crewReader = new CrewObjectJsonReader();
                var crews = new List<ITraktCrew>();
                ITraktCrew crew = await crewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (crew != null)
                {
                    crews.Add(crew);
                    crew = await crewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return crews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktCrew>));
        }
    }
}
