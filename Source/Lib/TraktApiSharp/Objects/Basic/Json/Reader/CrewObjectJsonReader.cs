namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewObjectJsonReader : IObjectJsonReader<ITraktCrew>
    {
        public Task<ITraktCrew> ReadObjectAsync(string json, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCrew));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCrew> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCrew));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var crewMembersReader = new CrewMemberArrayJsonReader();
                ITraktCrew traktCrew = new TraktCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CREW_PROPERTY_NAME_PRODUCTION:
                            traktCrew.Production = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_ART:
                            traktCrew.Art = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_CREW:
                            traktCrew.Crew = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP:
                            traktCrew.CostumeAndMakeup = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_DIRECTING:
                            traktCrew.Directing = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_WRITING:
                            traktCrew.Writing = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_SOUND:
                            traktCrew.Sound = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_CAMERA:
                            traktCrew.Camera = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_LIGHTING:
                            traktCrew.Lighting = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_VISUAL_EFFECTS:
                            traktCrew.VisualEffects = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_EDITING:
                            traktCrew.Editing = await crewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCrew;
            }

            return await Task.FromResult(default(ITraktCrew));
        }
    }
}
