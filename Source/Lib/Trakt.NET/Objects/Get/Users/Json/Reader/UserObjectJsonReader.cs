namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserObjectJsonReader : AObjectJsonReader<ITraktUser>
    {
        public override async Task<ITraktUser> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsReader = new UserIdsObjectJsonReader();
                var imagesReader = new UserImagesObjectJsonReader();

                ITraktUser traktUser = new TraktUser();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_USERNAME:
                            traktUser.Username = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PRIVATE:
                            traktUser.IsPrivate = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            traktUser.Ids = await idsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NAME:
                            traktUser.Name = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_VIP:
                            traktUser.IsVIP = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_VIP_EP:
                            traktUser.IsVIP_EP = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_JOINED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUser.JoinedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_LOCATION:
                            traktUser.Location = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_ABOUT:
                            traktUser.About = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_GENDER:
                            traktUser.Gender = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AGE:
                            traktUser.Age = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IMAGES:
                            traktUser.Images = await imagesReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUser;
            }

            return await Task.FromResult(default(ITraktUser));
        }
    }
}
