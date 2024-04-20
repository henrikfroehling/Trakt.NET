namespace TraktNet.Objects.Post.Notes.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using TraktNet.Objects.Get.Notes.Json.Reader;
    using TraktNet.Objects.Get.People.Json.Reader;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using TraktNet.Objects.Json;

    internal sealed class NotePostObjectJsonReader : AObjectJsonReader<ITraktNotePost>
    {
        public override async Task<ITraktNotePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var noteAttachedToReader = new NoteAttachedToObjectJsonReader();
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var personReader = new PersonObjectJsonReader();
             
                ITraktNotePost notePost = new TraktNotePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ATTACHED_TO:
                            notePost.AttachedTo = await noteAttachedToReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVACY:
                            notePost.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListPrivacy>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            notePost.Spoiler = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            notePost.Notes = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            notePost.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            notePost.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            notePost.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            notePost.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            notePost.Person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return notePost;
            }

            return await Task.FromResult(default(ITraktNotePost));
        }
    }
}
