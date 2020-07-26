namespace TraktNet.Objects.Basic.Json.Writer
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AMetadataObjectJsonWriter<TMetadataObjectType> : AObjectJsonWriter<TMetadataObjectType> where TMetadataObjectType : ITraktMetadata
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TMetadataObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteMetadataObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteMetadataObjectAsync(JsonTextWriter jsonWriter, TMetadataObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.MediaType != null && obj.MediaType != TraktMediaType.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MEDIA_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.MediaType.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.MediaResolution != null && obj.MediaResolution != TraktMediaResolution.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RESOLUTION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.MediaResolution.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Audio != null && obj.Audio != TraktMediaAudio.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_AUDIO, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Audio.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AudioChannels != null && obj.AudioChannels != TraktMediaAudioChannel.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_AUDIO_CHANNELS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AudioChannels.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ThreeDimensional.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_3D, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ThreeDimensional, cancellationToken).ConfigureAwait(false);
            }

            if (obj.HDR != null && obj.HDR != TraktMediaHDR.Unspecified)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_HDR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.HDR.ObjectName, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
