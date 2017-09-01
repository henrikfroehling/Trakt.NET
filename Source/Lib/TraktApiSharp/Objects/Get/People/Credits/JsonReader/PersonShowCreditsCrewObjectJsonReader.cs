namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewObjectJsonReader : IObjectJsonReader<ITraktPersonShowCreditsCrew>
    {
        private const string PROPERTY_NAME_PRODUCTION = "production";
        private const string PROPERTY_NAME_ART = "art";
        private const string PROPERTY_NAME_CREW = "crew";
        private const string PROPERTY_NAME_COSTUME_AND_MAKE_UP = "costume & make-up";
        private const string PROPERTY_NAME_DIRECTING = "directing";
        private const string PROPERTY_NAME_WRITING = "writing";
        private const string PROPERTY_NAME_SOUND = "sound";
        private const string PROPERTY_NAME_CAMERA = "camera";
        private const string PROPERTY_NAME_LIGHTING = "lighting";
        private const string PROPERTY_NAME_VISUAL_EFFECTS = "visual effects";
        private const string PROPERTY_NAME_EDITING = "editing";

        public Task<ITraktPersonShowCreditsCrew> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPersonShowCreditsCrew));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPersonShowCreditsCrew> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPersonShowCreditsCrew));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPersonShowCreditsCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonShowCreditsCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var creditsShowCrewItemsReader = new PersonShowCreditsCrewItemArrayJsonReader();

                ITraktPersonShowCreditsCrew movieCreditsCrew = new TraktPersonShowCreditsCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_PRODUCTION:
                            movieCreditsCrew.Production = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_ART:
                            movieCreditsCrew.Art = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_CREW:
                            movieCreditsCrew.Crew = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_COSTUME_AND_MAKE_UP:
                            movieCreditsCrew.CostumeAndMakeup = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_DIRECTING:
                            movieCreditsCrew.Directing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_WRITING:
                            movieCreditsCrew.Writing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SOUND:
                            movieCreditsCrew.Sound = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_CAMERA:
                            movieCreditsCrew.Camera = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LIGHTING:
                            movieCreditsCrew.Lighting = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_VISUAL_EFFECTS:
                            movieCreditsCrew.VisualEffects = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EDITING:
                            movieCreditsCrew.Editing = await creditsShowCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCreditsCrew;
            }

            return await Task.FromResult(default(ITraktPersonShowCreditsCrew));
        }
    }
}
