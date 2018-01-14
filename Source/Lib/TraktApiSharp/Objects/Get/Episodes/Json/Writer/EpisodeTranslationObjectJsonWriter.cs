namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeTranslationObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeTranslation>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeTranslation obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_TITLE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_OVERVIEW, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.LanguageCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.LanguageCode, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
