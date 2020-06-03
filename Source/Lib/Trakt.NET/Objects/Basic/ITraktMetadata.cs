namespace TraktNet.Objects.Basic
{
    using Enums;

    /// <summary>Contains metadata information for collection items.</summary>
    public interface ITraktMetadata
    {
        /// <summary>Gets or sets the media type. See also <seealso cref="TraktMediaType" />.<para>Nullable</para></summary>
        TraktMediaType MediaType { get; set; }

        /// <summary>Gets or sets the media resolution. See also <seealso cref="TraktMediaResolution" />.<para>Nullable</para></summary>
        TraktMediaResolution MediaResolution { get; set; }

        /// <summary>Gets or sets the media audio type. See also <seealso cref="TraktMediaAudio" />.<para>Nullable</para></summary>
        TraktMediaAudio Audio { get; set; }

        /// <summary>Gets or sets the media audio channels. See also <seealso cref="TraktMediaAudioChannel" />.<para>Nullable</para></summary>
        TraktMediaAudioChannel AudioChannels { get; set; }

        /// <summary>Gets or sets, whether the media is in 3D.</summary>
        bool? ThreeDimensional { get; set; }
    }
}
