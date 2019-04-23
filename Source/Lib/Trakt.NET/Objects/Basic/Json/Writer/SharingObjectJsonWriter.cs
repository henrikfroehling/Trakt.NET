namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingObjectJsonWriter : AObjectJsonWriter<ITraktSharing>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSharing obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Twitter.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_TWITTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Twitter, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Google.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_GOOGLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Google, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Tumblr.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_TUMBLR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tumblr, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Medium.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_MEDIUM, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Medium, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Slack.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_SLACK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Slack, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
