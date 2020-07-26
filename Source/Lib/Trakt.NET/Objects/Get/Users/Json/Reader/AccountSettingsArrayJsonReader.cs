namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AccountSettingsArrayJsonReader : ArrayJsonReader<ITraktAccountSettings>
    {
        public override async Task<IEnumerable<ITraktAccountSettings>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktAccountSettings>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var accountSettingsReader = new AccountSettingsObjectJsonReader();
                var accountSettingss = new List<ITraktAccountSettings>();
                ITraktAccountSettings accountSettings = await accountSettingsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (accountSettings != null)
                {
                    accountSettingss.Add(accountSettings);
                    accountSettings = await accountSettingsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return accountSettingss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktAccountSettings>));
        }
    }
}
