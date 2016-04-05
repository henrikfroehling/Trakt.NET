namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktAccessTokenTypeTests
    {
        [TestMethod]
        public void TestHasMembers()
        {
            typeof(TraktAccessTokenType).GetEnumNames().Should().HaveCount(1)
                                                       .And.Contain("Bearer");
        }

        [TestMethod]
        public void TestGetAsString()
        {
            TraktAccessTokenType.Bearer.AsString().Should().Be("bearer");
        }
    }
}
