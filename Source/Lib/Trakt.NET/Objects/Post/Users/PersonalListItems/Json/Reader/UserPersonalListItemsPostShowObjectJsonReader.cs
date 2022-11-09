namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostShowObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostShow>
    {
        public override async Task<ITraktUserPersonalListItemsPostShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showIdsObjectJsonReader = new ShowIdsObjectJsonReader();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostShowSeason>();
                ITraktUserPersonalListItemsPostShow customListItemsPostShow = new TraktUserPersonalListItemsPostShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            customListItemsPostShow.Ids = await showIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            customListItemsPostShow.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            customListItemsPostShow.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostShow;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostShow));
        }
    }
}
