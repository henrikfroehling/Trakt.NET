namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenTypeTests
    {
        [TestMethod]
        public void TestTraktAccessTokenTypeHasMembers()
        {
            typeof(TraktAccessTokenType).GetEnumNames().Should().HaveCount(2)
                                                       .And.Contain("Bearer", "Unspecified");
        }

        [TestMethod]
        public void TestTraktAccessTokenTypeGetAsString()
        {
            TraktAccessTokenType.Bearer.AsString().Should().Be("bearer");
            TraktAccessTokenType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
        }
    }
}
