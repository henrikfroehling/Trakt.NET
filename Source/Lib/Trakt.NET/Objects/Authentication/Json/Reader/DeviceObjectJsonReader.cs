namespace TraktNet.Objects.Authentication.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DeviceObjectJsonReader : AObjectJsonReader<ITraktDevice>
    {
        public override async Task<ITraktDevice> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktDevice));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktDevice traktAuthorization = new TraktDevice();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_DEVICE_CODE:
                            traktAuthorization.DeviceCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USER_CODE:
                            traktAuthorization.UserCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_VERIFICATION_URL:
                            traktAuthorization.VerificationUrl = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXPIRES_IN:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktAuthorization.ExpiresInSeconds = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_INTERVAL:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktAuthorization.IntervalInSeconds = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktAuthorization;
            }

            return await Task.FromResult(default(ITraktDevice));
        }
    }
}
