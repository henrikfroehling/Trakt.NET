namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewObjectJsonReader : AObjectJsonReader<ITraktPersonShowCreditsCrew>
    {
        public override async Task<ITraktPersonShowCreditsCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonShowCreditsCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var creditsShowCrewItemsReader = new PersonShowCreditsCrewItemArrayJsonReader();

                ITraktPersonShowCreditsCrew showCreditsCrew = new TraktPersonShowCreditsCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_PRODUCTION:
                            showCreditsCrew.Production = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_ART:
                            showCreditsCrew.Art = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_CREW:
                            showCreditsCrew.Crew = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP:
                            showCreditsCrew.CostumeAndMakeup = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_DIRECTING:
                            showCreditsCrew.Directing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_WRITING:
                            showCreditsCrew.Writing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_SOUND:
                            showCreditsCrew.Sound = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_CAMERA:
                            showCreditsCrew.Camera = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_LIGHTING:
                            showCreditsCrew.Lighting = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_VISUAL_EFFECTS:
                            showCreditsCrew.VisualEffects = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_SHOW_CREDITS_CREW_PROPERTY_NAME_EDITING:
                            showCreditsCrew.Editing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return showCreditsCrew;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCrew));
        }
    }
}
