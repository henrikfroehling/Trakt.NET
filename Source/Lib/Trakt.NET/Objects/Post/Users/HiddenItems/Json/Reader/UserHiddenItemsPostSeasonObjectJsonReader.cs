namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Get.Seasons.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostSeasonObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItemsPostSeason>
    {
        public override async Task<ITraktUserHiddenItemsPostSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserHiddenItemsPostSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var seasonIdsObjectJsonReader = new SeasonIdsObjectJsonReader();
                ITraktUserHiddenItemsPostSeason hiddenItemsPostSeason = new TraktUserHiddenItemsPostSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            hiddenItemsPostSeason.Ids = await seasonIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsPostSeason;
            }

            return await Task.FromResult(default(ITraktUserHiddenItemsPostSeason));
        }
    }
}
