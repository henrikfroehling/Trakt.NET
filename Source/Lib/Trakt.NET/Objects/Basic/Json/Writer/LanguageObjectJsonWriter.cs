namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class LanguageObjectJsonWriter : AObjectJsonWriter<ITraktLanguage>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktLanguage obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.LANGUAGE_PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Code))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.LANGUAGE_PROPERTY_NAME_CODE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Code, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
