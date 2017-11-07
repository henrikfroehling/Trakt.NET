namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktListType_Tests
    {
        [Fact]
        public void Test_TraktListType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktListType>() { TraktListType.Unspecified, TraktListType.Personal,
                                                                   TraktListType.Official, TraktListType.Watchlist,
                                                                   TraktListType.All });
        }
    }
}
