namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktListType_Tests
    {
        [Fact]
        public void Test_TraktListType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktListType>() { TraktListType.Unspecified, TraktListType.Personal,
                                                                   TraktListType.Official, TraktListType.Watchlist,
                                                                   TraktListType.Recommendations, TraktListType.All });
        }
    }
}
