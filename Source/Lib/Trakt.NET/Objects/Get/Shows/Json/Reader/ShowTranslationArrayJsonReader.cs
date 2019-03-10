namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowTranslationArrayJsonReader : AArrayJsonReader<ITraktShowTranslation>
    {
        public override async Task<IEnumerable<ITraktShowTranslation>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktShowTranslation>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var movieTranslationReader = new ShowTranslationObjectJsonReader();
                var traktShowTranslations = new List<ITraktShowTranslation>();
                ITraktShowTranslation traktShowTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (traktShowTranslation != null)
                {
                    traktShowTranslations.Add(traktShowTranslation);
                    traktShowTranslation = await movieTranslationReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return traktShowTranslations;
            }

            return await Task.FromResult(default(IEnumerable<ITraktShowTranslation>));
        }
    }
}
