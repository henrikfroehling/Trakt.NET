﻿namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MetadataObjectJsonWriter : AObjectJsonWriter<ITraktMetadata>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMetadata obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.MediaType != null && obj.MediaType != TraktMediaType.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.METADATA_PROPERTY_NAME_MEDIA_TYPE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.MediaType.ObjectName, cancellationToken);
            }

            if (obj.MediaResolution != null && obj.MediaResolution != TraktMediaResolution.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.METADATA_PROPERTY_NAME_RESOLUTION, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.MediaResolution.ObjectName, cancellationToken);
            }

            if (obj.Audio != null && obj.Audio != TraktMediaAudio.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.METADATA_PROPERTY_NAME_AUDIO, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Audio.ObjectName, cancellationToken);
            }

            if (obj.AudioChannels != null && obj.AudioChannels != TraktMediaAudioChannel.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.METADATA_PROPERTY_NAME_AUDIO_CHANNELS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.AudioChannels.ObjectName, cancellationToken);
            }

            if (obj.ThreeDimensional.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.METADATA_PROPERTY_NAME_3D, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.ThreeDimensional, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
