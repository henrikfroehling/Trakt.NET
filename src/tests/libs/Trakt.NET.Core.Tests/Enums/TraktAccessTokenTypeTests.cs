namespace TraktNET.Enums
{
    public sealed class TraktAccessTokenTypeTests
    {
        [Fact]
        public void TestTraktAccessTokenTypeToJson()
        {
            TraktAccessTokenType.Unspecified.ToJson().Should().BeNull();
            TraktAccessTokenType.Bearer.ToJson().Should().Be("bearer");
        }

        [Fact]
        public void TestTraktAccessTokenTypeFromJson()
        {
            "unspecified".ToTraktAccessTokenType().Should().Be(TraktAccessTokenType.Unspecified);
            "bearer".ToTraktAccessTokenType().Should().Be(TraktAccessTokenType.Bearer);

            string? nullValue = null;
            nullValue.ToTraktAccessTokenType().Should().Be(TraktAccessTokenType.Unspecified);
        }

        [Fact]
        public void TestTraktAccessTokenTypeDisplayName()
        {
            TraktAccessTokenType.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktAccessTokenType.Bearer.DisplayName().Should().Be("Bearer");
        }
    }
}
