namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastAndCrewObjectJsonReader : AObjectJsonReader<ITraktCastAndCrew>
    {
        public override async Task<ITraktCastAndCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var castReader = new ArrayJsonReader<ITraktCastMember>();
                var crewReader = new CrewObjectJsonReader();
                ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_CAST:
                            traktCastAndCrew.Cast = await castReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_CREW:
                            traktCastAndCrew.Crew = await crewReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCastAndCrew;
            }

            return await Task.FromResult(default(ITraktCastAndCrew));
        }
    }
}
