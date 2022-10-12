namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using TraktNet.Objects.Json;

    internal class UserPersonalListItemsPostSeasonObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostSeason>
    {
        public override async Task<ITraktUserPersonalListItemsPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsObjectJsonReader = new SeasonIdsObjectJsonReader();
                ITraktUserPersonalListItemsPostSeason customListItemsPostSeason = new TraktUserPersonalListItemsPostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            customListItemsPostSeason.Ids = await seasonIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            customListItemsPostSeason.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostSeason;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostSeason));
        }
    }
}
