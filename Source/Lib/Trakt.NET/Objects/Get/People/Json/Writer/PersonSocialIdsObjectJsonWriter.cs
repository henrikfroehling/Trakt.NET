namespace TraktNet.Objects.Get.People.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonSocialIdsObjectJsonWriter : AObjectJsonWriter<ITraktPersonSocialIds>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonSocialIds obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);

            if (!string.IsNullOrEmpty(obj.Twitter))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TWITTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Twitter, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Facebook))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FACEBOOK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Facebook, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Instagram))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_INSTAGRAM, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Instagram, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Wikipedia))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WIKIPEDIA, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Wikipedia, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
