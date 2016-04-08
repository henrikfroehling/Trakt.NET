namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessScopeTests
    {
        [TestMethod]
        public void TestTraktAccessScopeHasMembers()
        {
            typeof(TraktAccessScope).GetEnumNames().Should().HaveCount(4)
                                                   .And.Contain("Public", "Private", "Friends", "Unspecified");
        }

        [TestMethod]
        public void TestTraktAccessScopeGetAsString()
        {
            TraktAccessScope.Friends.AsString().Should().Be("friends");
            TraktAccessScope.Private.AsString().Should().Be("private");
            TraktAccessScope.Public.AsString().Should().Be("public");
            TraktAccessScope.Unspecified.AsString().Should().Be("");
        }
    }
}
