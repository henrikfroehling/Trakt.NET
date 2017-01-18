namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktCommentTests
    {
        [TestMethod]
        public void TestTraktCommentDefaultConstructor()
        {
            var comment = new TraktComment();

            comment.Id.Should().Be(0);
            comment.ParentId.Should().BeNull();
            comment.CreatedAt.Should().Be(DateTime.MinValue);
            comment.UpdatedAt.Should().NotHaveValue();
            comment.Comment.Should().BeNullOrEmpty();
            comment.Spoiler.Should().BeFalse();
            comment.Review.Should().BeFalse();
            comment.Replies.Should().NotHaveValue();
            comment.Likes.Should().NotHaveValue();
            comment.UserRating.Should().NotHaveValue();
            comment.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCommentReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Comment.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var comment = JsonConvert.DeserializeObject<TraktComment>(jsonFile);

            comment.Should().NotBeNull();
            comment.Id.Should().Be(76957U);
            comment.ParentId.Should().Be(0U);
            comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            comment.Spoiler.Should().BeFalse();
            comment.Review.Should().BeFalse();
            comment.Replies.Should().Be(1);
            comment.Likes.Should().Be(2);
            comment.UserRating.Should().Be(7.3f);
            comment.User.Should().NotBeNull();
        }
    }
}
