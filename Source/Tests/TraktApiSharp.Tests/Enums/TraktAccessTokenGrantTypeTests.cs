namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenGrantTypeTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktAccessTokenGrantType).GetEnumNames().Should().HaveCount(3)
                                                            .And.Contain("AuthorizationCode", "RefreshToken", "Unspecified");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktAccessTokenGrantType.AuthorizationCode.AsString().Should().Be("authorization_code");
            TraktAccessTokenGrantType.RefreshToken.AsString().Should().Be("refresh_token");
            TraktAccessTokenGrantType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
