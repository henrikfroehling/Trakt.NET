namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaAudio_Tests
    {
        [Fact]
        public void Test_TraktMediaAudio_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaAudio>();

            allValues.Should().NotBeNull().And.HaveCount(16);
            allValues.Should().Contain(new List<TraktMediaAudio>() { TraktMediaAudio.Unspecified, TraktMediaAudio.LPCM,
                                                                     TraktMediaAudio.MP3, TraktMediaAudio.AAC,
                                                                     TraktMediaAudio.OGG, TraktMediaAudio.WMA,
                                                                     TraktMediaAudio.DTS, TraktMediaAudio.DTS_MA,
                                                                     TraktMediaAudio.DTS_X, TraktMediaAudio.DolbyPrologic,
                                                                     TraktMediaAudio.DolbyDigital, TraktMediaAudio.DolbyDigitalPlus,
                                                                     TraktMediaAudio.DolbyTrueHD, TraktMediaAudio.DolbyAtmos,
                                                                     TraktMediaAudio.DTS_HR, TraktMediaAudio.AURO_3D });
        }
    }
}
