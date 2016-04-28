namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktCommentTypeTests
    {
        [TestMethod]
        public void TestTraktCommentTypeHasMembers()
        {
            typeof(TraktCommentType).GetEnumNames().Should().HaveCount(4)
                                                   .And.Contain("Unspecified", "Review", "Shout", "All");
        }

        [TestMethod]
        public void TestTraktCommentTypeGetAsStringUriParameter()
        {
            TraktCommentType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktCommentType.Review.AsStringUriParameter().Should().Be("reviews");
            TraktCommentType.Shout.AsStringUriParameter().Should().Be("shouts");
        }
    }
}
