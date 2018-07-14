namespace TraktNet.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktReleaseType_Tests
    {
        [Fact]
        public void Test_TraktReleaseType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktReleaseType>();

            allValues.Should().NotBeNull().And.HaveCount(8);
            allValues.Should().Contain(new List<TraktReleaseType>() { TraktReleaseType.Unspecified, TraktReleaseType.Unknown,
                                                                      TraktReleaseType.Premiere, TraktReleaseType.Limited,
                                                                      TraktReleaseType.Theatrical, TraktReleaseType.Digital,
                                                                      TraktReleaseType.Physical, TraktReleaseType.TV });
        }
    }
}
