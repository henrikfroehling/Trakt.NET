namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Basic.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserSettingsObjectJsonReader : IObjectJsonReader<ITraktUserSettings>
    {
        private const string PROPERTY_NAME_USER = "user";
        private const string PROPERTY_NAME_ACCOUNT = "account";
        private const string PROPERTY_NAME_CONNECTIONS = "connections";
        private const string PROPERTY_NAME_SHARING_TEXT = "sharing_text";

        public Task<ITraktUserSettings> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserSettings));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserSettings> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserSettings));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserSettings> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserSettings));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new TraktUserObjectJsonReader();
                var accountSettingsReader = new AccountSettingsObjectJsonReader();
                var sharingReader = new SharingObjectJsonReader();
                var sharingTextReader = new SharingTextObjectJsonReader();

                ITraktUserSettings traktUserSettings = new TraktUserSettings();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_USER:
                            traktUserSettings.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_ACCOUNT:
                            traktUserSettings.Account = await accountSettingsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_CONNECTIONS:
                            traktUserSettings.Connections = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHARING_TEXT:
                            traktUserSettings.SharingText = await sharingTextReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserSettings;
            }

            return await Task.FromResult(default(ITraktUserSettings));
        }
    }
}
