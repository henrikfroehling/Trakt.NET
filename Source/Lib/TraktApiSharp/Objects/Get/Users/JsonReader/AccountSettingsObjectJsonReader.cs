namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AccountSettingsObjectJsonReader : IObjectJsonReader<ITraktAccountSettings>
    {
        private const string PROPERTY_NAME_TIMEZONE_ID = "timezone";
        private const string PROPERTY_NAME_TIME_24HR = "time_24hr";
        private const string PROPERTY_NAME_COVER_IMAGE = "cover_image";

        public Task<ITraktAccountSettings> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktAccountSettings));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktAccountSettings> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktAccountSettings));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktAccountSettings> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_TIMEZONE_ID:
                            traktAccountSettings.TimeZoneId = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_TIME_24HR:
                            traktAccountSettings.Time24Hr = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_COVER_IMAGE:
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
