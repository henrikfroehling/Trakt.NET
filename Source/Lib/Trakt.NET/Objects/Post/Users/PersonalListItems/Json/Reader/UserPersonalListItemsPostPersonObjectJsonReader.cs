namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.People.Json.Reader;
    using TraktNet.Objects.Json;

    internal class UserPersonalListItemsPostPersonObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostPerson>
    {
        public override async Task<ITraktUserPersonalListItemsPostPerson> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var personIdsObjectJsonReader = new PersonIdsObjectJsonReader();
                ITraktUserPersonalListItemsPostPerson customListItemsPostPerson = new TraktUserPersonalListItemsPostPerson();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_IDS:
                            customListItemsPostPerson.Ids = await personIdsObjectJsonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOTES:
                            customListItemsPostPerson.Notes = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostPerson;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostPerson));
        }
    }
}
