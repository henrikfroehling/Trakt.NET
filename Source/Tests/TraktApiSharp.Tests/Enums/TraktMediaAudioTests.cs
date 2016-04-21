namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaAudioTests
    {
        [TestMethod]
        public void TestTraktMediaAudioHasMembers()
        {
            typeof(TraktMediaAudio).GetEnumNames().Should().HaveCount(12)
                                                  .And.Contain("Unspecified", "LPCM", "MP3", "AAC", "OGG", "WMA",
                                                               "DTS", "DTS_MA", "DolbyPrologic", "DolbyDigital", "DolbyDigitalPlus", "DolbyTrueHD");
        }

        [TestMethod]
        public void TestTraktMediaAudioGetAsString()
        {
            TraktMediaAudio.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaAudio.LPCM.AsString().Should().Be("lpcm");
            TraktMediaAudio.MP3.AsString().Should().Be("mp3");
            TraktMediaAudio.AAC.AsString().Should().Be("aac");
            TraktMediaAudio.OGG.AsString().Should().Be("ogg");
            TraktMediaAudio.WMA.AsString().Should().Be("wma");
            TraktMediaAudio.DTS.AsString().Should().Be("dts");
            TraktMediaAudio.DTS_MA.AsString().Should().Be("dts_ma");
            TraktMediaAudio.DolbyPrologic.AsString().Should().Be("dolby_prologic");
            TraktMediaAudio.DolbyDigital.AsString().Should().Be("dolby_digital");
            TraktMediaAudio.DolbyDigitalPlus.AsString().Should().Be("dolby_digital_plus");
            TraktMediaAudio.DolbyTrueHD.AsString().Should().Be("dolby_truehd");
        }
    }
}
