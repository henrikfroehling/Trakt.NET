namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktMediaResolution_Tests
    {
        [Fact]
        public void Test_TraktMediaResolution_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaResolution>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaResolution>() { TraktMediaResolution.Unspecified, TraktMediaResolution.UHD_4k,
                                                                          TraktMediaResolution.HD_1080p, TraktMediaResolution.HD_1080i,
                                                                          TraktMediaResolution.HD_720p, TraktMediaResolution.SD_480p,
                                                                          TraktMediaResolution.SD_480i, TraktMediaResolution.SD_576p,
                                                                          TraktMediaResolution.SD_576i });
        }
    }
}
