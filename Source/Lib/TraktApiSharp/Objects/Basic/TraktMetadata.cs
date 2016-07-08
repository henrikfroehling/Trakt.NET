namespace TraktApiSharp.Objects.Basic
{
    using Enums;
    using Newtonsoft.Json;

    public class TraktMetadata
    {
        [JsonProperty(PropertyName = "media_type")]
        [JsonConverter(typeof(TraktMediaTypeConverter))]
        public TraktMediaType? MediaType { get; set; }

        [JsonProperty(PropertyName = "resolution")]
        [JsonConverter(typeof(TraktMediaResolutionConverter))]
        public TraktMediaResolution? MediaResolution { get; set; }

        [JsonProperty(PropertyName = "audio")]
        [JsonConverter(typeof(TraktMediaAudioConverter))]
        public TraktMediaAudio? Audio { get; set; }

        [JsonProperty(PropertyName = "audio_channels")]
        [JsonConverter(typeof(TraktMediaAudioChannelConverter))]
        public TraktMediaAudioChannel? AudioChannels { get; set; }

        [JsonProperty(PropertyName = "3d")]
        public bool? ThreeDimensional { get; set; }
    }
}
