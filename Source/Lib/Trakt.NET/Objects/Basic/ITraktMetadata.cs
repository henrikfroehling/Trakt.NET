namespace TraktNet.Objects.Basic
{
    using Enums;

    public interface ITraktMetadata
    {
        TraktMediaType MediaType { get; set; }

        TraktMediaResolution MediaResolution { get; set; }

        TraktMediaAudio Audio { get; set; }

        TraktMediaAudioChannel AudioChannels { get; set; }

        TraktMediaHDR HDR { get; set; }

        bool? ThreeDimensional { get; set; }
    }
}
