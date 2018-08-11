namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserImagesArrayJsonReader : AArrayJsonReader<ITraktUserImages>
    {
        public override async Task<IEnumerable<ITraktUserImages>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktUserImages>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var userImagesReader = new UserImagesObjectJsonReader();
                var userImagess = new List<ITraktUserImages>();
                ITraktUserImages userImages = await userImagesReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (userImages != null)
                {
                    userImagess.Add(userImages);
                    userImages = await userImagesReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return userImagess;
            }

            return await Task.FromResult(default(IEnumerable<ITraktUserImages>));
        }
    }
}
