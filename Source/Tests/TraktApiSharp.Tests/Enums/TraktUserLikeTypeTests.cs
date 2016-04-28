namespace TraktApiSharp.Tests.Enums
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;

    [TestClass]
    public class TraktUserLikeTypeTests
    {
        [TestMethod]
        public void TestTraktUserLikeTypeHasMembers()
        {
            typeof(TraktUserLikeType).GetEnumNames().Should().HaveCount(3)
                                                         .And.Contain("Unspecified", "Comment", "List");
        }

        [TestMethod]
        public void TestTraktUserLikeTypeGetAsString()
        {
            TraktUserLikeType.Unspecified.AsString().Should().NotBeNull().And.BeEmpty();
            TraktUserLikeType.Comment.AsString().Should().Be("comment");
            TraktUserLikeType.List.AsString().Should().Be("list");
        }

        [TestMethod]
        public void TestTraktUserLikeTypeGetAsStringUriParameter()
        {
            TraktUserLikeType.Unspecified.AsStringUriParameter().Should().NotBeNull().And.BeEmpty();
            TraktUserLikeType.Comment.AsStringUriParameter().Should().Be("comments");
            TraktUserLikeType.List.AsStringUriParameter().Should().Be("lists");
        }
    }
}
