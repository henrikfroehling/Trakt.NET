namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AccountSettingsObjectJsonReader : AObjectJsonReader<ITraktAccountSettings>
    {
        public override async Task<ITraktAccountSettings> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktAccountSettings));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktAccountSettings traktAccountSettings = new TraktAccountSettings();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_TIMEZONE_ID:
                            traktAccountSettings.TimeZoneId = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_TIME_24HR:
                            traktAccountSettings.Time24Hr = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_COVER_IMAGE:
                            traktAccountSettings.CoverImage = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktAccountSettings;
            }

            return await Task.FromResult(default(ITraktAccountSettings));
        }
    }
}
