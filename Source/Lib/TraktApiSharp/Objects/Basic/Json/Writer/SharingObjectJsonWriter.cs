﻿namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingObjectJsonWriter : AObjectJsonWriter<ITraktSharing>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSharing obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Facebook.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_FACEBOOK, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Facebook, cancellationToken);
            }

            if (obj.Twitter.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_TWITTER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Twitter, cancellationToken);
            }

            if (obj.Google.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_GOOGLE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Google, cancellationToken);
            }

            if (obj.Tumblr.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_TUMBLR, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Tumblr, cancellationToken);
            }

            if (obj.Medium.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_MEDIUM, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Medium, cancellationToken);
            }

            if (obj.Slack.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_PROPERTY_NAME_SLACK, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Slack, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
