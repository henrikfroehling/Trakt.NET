namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingTextArrayJsonReader : ArrayJsonReader<ITraktSharingText>
    {
        public override async Task<IEnumerable<ITraktSharingText>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktSharingText>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var sharingTextReader = new SharingTextObjectJsonReader();
                var sharingTexts = new List<ITraktSharingText>();
                ITraktSharingText sharingText = await sharingTextReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (sharingText != null)
                {
                    sharingTexts.Add(sharingText);
                    sharingText = await sharingTextReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return sharingTexts;
            }

            return await Task.FromResult(default(IEnumerable<ITraktSharingText>));
        }
    }
}
