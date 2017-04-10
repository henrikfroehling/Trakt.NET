namespace TraktApiSharp.Objects.Basic.Implementations
{
    using Enums;
    using Newtonsoft.Json;

    /// <summary>Contains metadata information for collection items.</summary>
    public class TraktMetadata : ITraktMetadata
    {
        /// <summary>Gets or sets the media type. See also <seealso cref="TraktMediaType" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "media_type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaType>))]
        public TraktMediaType MediaType { get; set; }

        /// <summary>Gets or sets the media resolution. See also <seealso cref="TraktMediaResolution" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "resolution")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaResolution>))]
        public TraktMediaResolution MediaResolution { get; set; }

        /// <summary>Gets or sets the media audio type. See also <seealso cref="TraktMediaAudio" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "audio")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaAudio>))]
        public TraktMediaAudio Audio { get; set; }

        /// <summary>Gets or sets the media audio channels. See also <seealso cref="TraktMediaAudioChannel" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "audio_channels")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktMediaAudioChannel>))]
        public TraktMediaAudioChannel AudioChannels { get; set; }

        /// <summary>Gets or sets, whether the media is in 3D.</summary>
        [JsonProperty(PropertyName = "3d")]
        public bool? ThreeDimensional { get; set; }
    }
}
