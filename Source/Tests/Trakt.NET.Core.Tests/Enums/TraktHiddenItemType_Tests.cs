namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktHiddenItemType_Tests
    {
        [Fact]
        public void Test_TraktHiddenItemType_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktHiddenItemType>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktHiddenItemType>() { TraktHiddenItemType.Unspecified, TraktHiddenItemType.Movie,
                                                                         TraktHiddenItemType.Show, TraktHiddenItemType.Season,
                                                                         TraktHiddenItemType.User });
        }

        [Fact]
        public void Test_TraktHiddenItemType_Properties()
        {
            TraktHiddenItemType.Movie.Value.Should().Be(1);
            TraktHiddenItemType.Movie.ObjectName.Should().Be("movie");
            TraktHiddenItemType.Movie.UriName.Should().Be("movie");
            TraktHiddenItemType.Movie.DisplayName.Should().Be("Movie");

            TraktHiddenItemType.Show.Value.Should().Be(2);
            TraktHiddenItemType.Show.ObjectName.Should().Be("show");
            TraktHiddenItemType.Show.UriName.Should().Be("show");
            TraktHiddenItemType.Show.DisplayName.Should().Be("Show");

            TraktHiddenItemType.Season.Value.Should().Be(4);
            TraktHiddenItemType.Season.ObjectName.Should().Be("season");
            TraktHiddenItemType.Season.UriName.Should().Be("season");
            TraktHiddenItemType.Season.DisplayName.Should().Be("Season");

            TraktHiddenItemType.User.Value.Should().Be(8);
            TraktHiddenItemType.User.ObjectName.Should().Be("user");
            TraktHiddenItemType.User.UriName.Should().Be("user");
            TraktHiddenItemType.User.DisplayName.Should().Be("User");
        }
    }
}
