namespace TraktNet.Core.Tests.Enums
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using Xunit;

    [TestCategory("Enums")]
    public class TraktListPrivacy_Tests
    {
        [Fact]
        public void Test_TraktListPrivacy_GetAll()
        {
            var allValues = TraktEnumeration.GetAll<TraktListPrivacy>();

            allValues.Should().NotBeNull().And.HaveCount(5);
            allValues.Should().Contain(new List<TraktListPrivacy>() { TraktListPrivacy.Unspecified, TraktListPrivacy.Private,
                                                                      TraktListPrivacy.Link, TraktListPrivacy.Friends,
                                                                      TraktListPrivacy.Public });
        }

        [Fact]
        public void Test_TraktListPrivacy_Properties()
        {
            TraktListPrivacy.Private.Value.Should().Be(1);
            TraktListPrivacy.Private.ObjectName.Should().Be("private");
            TraktListPrivacy.Private.UriName.Should().Be("private");
            TraktListPrivacy.Private.DisplayName.Should().Be("Private");

            TraktListPrivacy.Link.Value.Should().Be(2);
            TraktListPrivacy.Link.ObjectName.Should().Be("link");
            TraktListPrivacy.Link.UriName.Should().Be("link");
            TraktListPrivacy.Link.DisplayName.Should().Be("Link");

            TraktListPrivacy.Friends.Value.Should().Be(4);
            TraktListPrivacy.Friends.ObjectName.Should().Be("friends");
            TraktListPrivacy.Friends.UriName.Should().Be("friends");
            TraktListPrivacy.Friends.DisplayName.Should().Be("Friends");

            TraktListPrivacy.Public.Value.Should().Be(8);
            TraktListPrivacy.Public.ObjectName.Should().Be("public");
            TraktListPrivacy.Public.UriName.Should().Be("public");
            TraktListPrivacy.Public.DisplayName.Should().Be("Public");
        }
    }
}
