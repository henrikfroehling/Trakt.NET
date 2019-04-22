namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktSearchResultType_Tests
    {
        [Fact]
        public void Test_TraktSearchResultType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktSearchResultType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktSearchResultType>() { TraktSearchResultType.Unspecified, TraktSearchResultType.Movie,
                                                                           TraktSearchResultType.Show, TraktSearchResultType.Episode,
                                                                           TraktSearchResultType.Person, TraktSearchResultType.List });
        }
    }
}
