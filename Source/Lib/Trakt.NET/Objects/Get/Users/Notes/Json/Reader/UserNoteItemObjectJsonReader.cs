namespace TraktNet.Objects.Get.Users.Notes.Json.Reader
{
    using Enums;
    using Get.Episodes.Json.Reader;
    using Get.Movies.Json.Reader;
    using Get.People.Json.Reader;
    using Get.Seasons.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserNoteItemObjectJsonReader : AObjectJsonReader<ITraktUserNoteItem>
    {
        public override async Task<ITraktUserNoteItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var attachedToObjectReader = new UserNoteAttachedToObjectJsonReader();
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var seasonObjectReader = new SeasonObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();
                var personObjectReader = new PersonObjectJsonReader();
                var noteObjectReader = new UserNoteObjectJsonReader();

                ITraktUserNoteItem userNoteItem = new TraktUserNoteItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ATTACHED_TO:
                            userNoteItem.AttachedTo = await attachedToObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            userNoteItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            userNoteItem.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            userNoteItem.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASON:
                            userNoteItem.Season = await seasonObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            userNoteItem.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            userNoteItem.Person = await personObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTE:
                            userNoteItem.Note = await noteObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userNoteItem;
            }

            return await Task.FromResult(default(ITraktUserNoteItem));
        }
    }
}
