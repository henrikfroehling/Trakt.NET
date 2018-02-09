namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAliasObjectJsonWriter : AObjectJsonWriter<ITraktShowAlias>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowAlias obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_ALIAS_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CountryCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_ALIAS_PROPERTY_NAME_COUNTRY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CountryCode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
