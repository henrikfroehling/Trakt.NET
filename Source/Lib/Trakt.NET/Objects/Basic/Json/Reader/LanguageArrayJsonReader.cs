namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class LanguageArrayJsonReader : AArrayJsonReader<ITraktLanguage>
    {
        public override async Task<IEnumerable<ITraktLanguage>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktLanguage>)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var languageReader = new LanguageObjectJsonReader();
                var languages = new List<ITraktLanguage>();
                ITraktLanguage language = await languageReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                while (language != null)
                {
                    languages.Add(language);
                    language = await languageReader.ReadObjectAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                }


                return languages;
            }

            return await Task.FromResult(default(IEnumerable<ITraktLanguage>)).ConfigureAwait(false);
        }
    }
}
