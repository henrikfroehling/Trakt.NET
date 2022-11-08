namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using TraktNet.Objects.Json;

    internal class UserPersonalListItemsPostEpisodeObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostEpisode>
    {
        public override async Task<ITraktUserPersonalListItemsPostEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeIdsObjectJsonReader = new EpisodeIdsObjectJsonReader();
                ITraktUserPersonalListItemsPostEpisode customListItemsPostEpisode = new TraktUserPersonalListItemsPostEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            customListItemsPostEpisode.Ids = await episodeIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            customListItemsPostEpisode.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostEpisode;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostEpisode));
        }
    }
}
