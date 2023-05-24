namespace TraktNet.Objects.Get.Lists.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Json.Reader;

    internal class ListObjectJsonReader : AObjectJsonReader<ITraktList>
    {
        public override async Task<ITraktList> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsReader = new ListIdsObjectJsonReader();
                var userReader = new UserObjectJsonReader();
                ITraktList traktList = new TraktList();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NAME:
                            traktList.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DESCRIPTION:
                            traktList.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVACY:
                            traktList.Privacy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListPrivacy>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_DISPLAY_NUMBERS:
                            traktList.DisplayNumbers = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ALLOW_COMMENTS:
                            traktList.AllowComments = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_BY:
                            traktList.SortBy = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_HOW:
                            traktList.SortHow = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_CREATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktList.CreatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktList.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_ITEM_COUNT:
                            traktList.ItemCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENT_COUNT:
                            traktList.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIKES:
                            traktList.Likes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktList.Ids = await idsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USER:
                            traktList.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktList;
            }

            return await Task.FromResult(default(ITraktList));
        }
    }
}
