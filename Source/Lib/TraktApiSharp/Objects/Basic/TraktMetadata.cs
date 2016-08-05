namespace TraktApiSharp.Objects.Basic
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>Contains metadata information for collection items.</summary>
    public class TraktMetadata
    {
        /// <summary>Gets or sets the media type. See also <seealso cref="TraktMediaType" />.</summary>
        [JsonProperty(PropertyName = "media_type")]
        [JsonConverter(typeof(TraktMediaTypeConverter))]
        public TraktMediaType? MediaType { get; set; }

        /// <summary>Gets or sets the media resolution. See also <seealso cref="TraktMediaResolution" />.</summary>
        [JsonProperty(PropertyName = "resolution")]
        [JsonConverter(typeof(TraktMediaResolutionConverter))]
        public TraktMediaResolution? MediaResolution { get; set; }

        /// <summary>Gets or sets the media audio type. See also <seealso cref="TraktMediaAudio" />.</summary>
        [JsonProperty(PropertyName = "audio")]
        [JsonConverter(typeof(TraktMediaAudioConverter))]
        public TraktMediaAudio? Audio { get; set; }

        /// <summary>Gets or sets the media audio channels. See also <seealso cref="TraktMediaAudioChannel" />.</summary>
        [JsonProperty(PropertyName = "audio_channels")]
        [JsonConverter(typeof(TraktMediaAudioChannelConverter))]
        public TraktMediaAudioChannel? AudioChannels { get; set; }

        /// <summary>Gets or sets, whether the media is in 3D.</summary>
        [JsonProperty(PropertyName = "3d")]
        public bool? ThreeDimensional { get; set; }
    }
}
