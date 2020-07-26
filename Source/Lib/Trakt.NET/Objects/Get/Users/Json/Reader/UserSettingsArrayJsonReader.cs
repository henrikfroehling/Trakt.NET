namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSettingsArrayJsonReader : ArrayJsonReader<ITraktUserSettings>
    {
        public override async Task<IEnumerable<ITraktUserSettings>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserSettings>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userSettingsReader = new UserSettingsObjectJsonReader();
                var userSettingss = new List<ITraktUserSettings>();
                ITraktUserSettings userSettings = await userSettingsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userSettings != null)
                {
                    userSettingss.Add(userSettings);
                    userSettings = await userSettingsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userSettingss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserSettings>));
        }
    }
}
