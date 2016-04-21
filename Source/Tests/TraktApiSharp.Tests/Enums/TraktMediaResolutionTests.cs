namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktMediaResolutionTests
    {
        [TestMethod]
        public void TestTraktMediaResolutionHasMembers()
        {
            typeof(TraktMediaResolution).GetEnumNames().Should().HaveCount(9)
                                                       .And.Contain("Unspecified", "UHD_4k", "HD_1080p", "HD_1080i", "HD_720p",
                                                                    "SD_480p", "SD_480i", "SD_576p", "SD_576i");
        }

        [TestMethod]
        public void TestTraktMediaResolutionGetAsString()
        {
            TraktMediaResolution.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktMediaResolution.UHD_4k.AsString().Should().Be("uhd_4k");
            TraktMediaResolution.HD_1080p.AsString().Should().Be("hd_1080p");
            TraktMediaResolution.HD_1080i.AsString().Should().Be("hd_1080i");
            TraktMediaResolution.HD_720p.AsString().Should().Be("hd_720p");
            TraktMediaResolution.SD_480p.AsString().Should().Be("sd_480p");
            TraktMediaResolution.SD_480i.AsString().Should().Be("sd_480i");
            TraktMediaResolution.SD_576p.AsString().Should().Be("sd_576p");
            TraktMediaResolution.SD_576i.AsString().Should().Be("sd_576i");
        }
    }
}
