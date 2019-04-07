namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [Category("Enums")]
    public class TraktRatingsItemType_Tests
    {
        [Fact]
        public void Test_TraktRatingsItemTyp_eGetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktRatingsItemType>();

            allValues.Should().NotBeNull().And.HaveCount(6);
            allValues.Should().Contain(new List<TraktRatingsItemType>() { TraktRatingsItemType.Unspecified,
                                                                          TraktRatingsItemType.Movie,
                                                                          TraktRatingsItemType.Show,
                                                                          TraktRatingsItemType.Season,
                                                                          TraktRatingsItemType.Episode,
                                                                          TraktRatingsItemType.All });
        }
    }
}
