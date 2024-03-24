namespace TraktNET.Enums
{
    public sealed class TraktAccessScopeTests
    {
        [Fact]
        public void TestTraktAccessScopeToJson()
        {
            TraktAccessScope.Unspecified.ToJson().Should().BeNull();
            TraktAccessScope.Private.ToJson().Should().Be("private");
            TraktAccessScope.Friends.ToJson().Should().Be("friends");
            TraktAccessScope.Public.ToJson().Should().Be("public");
        }

        [Fact]
        public void TestTraktAccessScopeFromJson()
        {
            "unspecified".ToTraktAccessScope().Should().Be(TraktAccessScope.Unspecified);
            "private".ToTraktAccessScope().Should().Be(TraktAccessScope.Private);
            "friends".ToTraktAccessScope().Should().Be(TraktAccessScope.Friends);
            "public".ToTraktAccessScope().Should().Be(TraktAccessScope.Public);

            string? nullValue = null;
            nullValue.ToTraktAccessScope().Should().Be(TraktAccessScope.Unspecified);
        }

        [Fact]
        public void TestTraktAccessScopeDisplayName()
        {
            TraktAccessScope.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktAccessScope.Private.DisplayName().Should().Be("Private");
            TraktAccessScope.Friends.DisplayName().Should().Be("Friends");
            TraktAccessScope.Public.DisplayName().Should().Be("Public");
        }
    }
}
