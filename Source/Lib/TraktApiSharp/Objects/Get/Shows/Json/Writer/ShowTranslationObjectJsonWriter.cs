namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowTranslationObjectJsonWriter : AObjectJsonWriter<ITraktShowTranslation>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowTranslation obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_OVERVIEW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.LanguageCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_TRANSLATION_PROPERTY_NAME_LANGUAGE_CODE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LanguageCode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
