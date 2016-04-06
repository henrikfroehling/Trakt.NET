namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects;
    using Utils;

    [TestClass]
    public class TraktCommentTests
    {
        [TestMethod]
        public void TestTraktCommentDefaultConstructor()
        {
            var comment = new TraktComment();

            comment.Id.Should().NotHaveValue();
            comment.ParentId.Should().NotHaveValue();
            comment.CreatedAt.Should().NotHaveValue();
            comment.Comment.Should().BeNullOrEmpty();
            comment.Spoiler.Should().NotHaveValue();
            comment.Review.Should().NotHaveValue();
            comment.Replies.Should().NotHaveValue();
            comment.Likes.Should().NotHaveValue();
            comment.UserRating.Should().NotHaveValue();
            comment.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCommentReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\Comment.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var comment = JsonConvert.DeserializeObject<TraktComment>(jsonFile);

            comment.Should().NotBeNull();
            comment.Id.Should().Be(76957);
            comment.ParentId.Should().Be(0);
            comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            comment.Spoiler.Should().BeFalse();
            comment.Review.Should().BeFalse();
            comment.Replies.Should().Be(1);
            comment.Likes.Should().Be(2);
            comment.UserRating.Should().Be(7.3m);
            comment.User.Should().NotBeNull();
        }
    }
}
