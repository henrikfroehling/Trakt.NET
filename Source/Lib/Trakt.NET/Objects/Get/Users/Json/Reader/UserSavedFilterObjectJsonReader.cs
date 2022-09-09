namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSavedFilterObjectJsonReader : AObjectJsonReader<ITraktUserSavedFilter>
    {
        public override async Task<ITraktUserSavedFilter> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserSavedFilter traktUserSavedFilter = new TraktUserSavedFilter();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserSavedFilter.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SECTION:
                            traktUserSavedFilter.Section = await JsonReaderHelper.ReadEnumerationValueAsync<TraktFilterSection>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NAME:
                            traktUserSavedFilter.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PATH:
                            traktUserSavedFilter.Path = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_QUERY:
                            traktUserSavedFilter.Query = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserSavedFilter.UpdatedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserSavedFilter;
            }

            return await Task.FromResult(default(ITraktUserSavedFilter));
        }
    }
}
