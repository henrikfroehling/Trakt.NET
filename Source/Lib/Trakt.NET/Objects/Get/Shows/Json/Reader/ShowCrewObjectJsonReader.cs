namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCrewObjectJsonReader : AObjectJsonReader<ITraktShowCrew>
    {
        public override async Task<ITraktShowCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showCrewMembersReader = new ShowCrewMemberArrayJsonReader();
                ITraktShowCrew traktCrew = new TraktShowCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CREW_PROPERTY_NAME_PRODUCTION:
                            traktCrew.Production = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_ART:
                            traktCrew.Art = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_CREW:
                            traktCrew.Crew = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP:
                            traktCrew.CostumeAndMakeup = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_DIRECTING:
                            traktCrew.Directing = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_WRITING:
                            traktCrew.Writing = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_SOUND:
                            traktCrew.Sound = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_CAMERA:
                            traktCrew.Camera = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_LIGHTING:
                            traktCrew.Lighting = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_VISUAL_EFFECTS:
                            traktCrew.VisualEffects = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.CREW_PROPERTY_NAME_EDITING:
                            traktCrew.Editing = await showCrewMembersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCrew;
            }

            return await Task.FromResult(default(ITraktShowCrew));
        }
    }
}
