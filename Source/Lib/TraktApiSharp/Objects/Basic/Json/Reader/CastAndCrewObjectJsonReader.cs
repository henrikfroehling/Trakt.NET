namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastAndCrewObjectJsonReader : AObjectJsonReader<ITraktCastAndCrew>
    {
        public override async Task<ITraktCastAndCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCastAndCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var castReader = new CastMemberArrayJsonReader();
                var crewReader = new CrewObjectJsonReader();
                ITraktCastAndCrew traktCastAndCrew = new TraktCastAndCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CAST_AND_CREW_PROPERTY_NAME_CAST:
                            traktCastAndCrew.Cast = await castReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CAST_AND_CREW_PROPERTY_NAME_CREW:
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
