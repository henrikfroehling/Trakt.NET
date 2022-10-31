namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktMediaType_Tests
    {
        [Fact]
        public void Test_TraktMediaType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktMediaType>();

            allValues.Should().NotBeNull().And.HaveCount(9);
            allValues.Should().Contain(new List<TraktMediaType>() { TraktMediaType.Unspecified, TraktMediaType.Digital,
                                                                    TraktMediaType.Bluray, TraktMediaType.HD_DVD,
                                                                    TraktMediaType.DVD, TraktMediaType.VCD,
                                                                    TraktMediaType.VHS, TraktMediaType.BetaMax,
                                                                    TraktMediaType.LaserDisc });
        }
    }
}
