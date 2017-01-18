namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserCommentTests
    {
        [TestMethod]
        public void TestTraktUserCommentDefaultConstructor()
        {
            var userComment = new TraktUserComment();

            userComment.Type.Should().BeNull();
            userComment.Comment.Should().BeNull();
            userComment.Movie.Should().BeNull();
            userComment.Show.Should().BeNull();
            userComment.Season.Should().BeNull();
            userComment.Episode.Should().BeNull();
            userComment.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserCommentReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userComments = JsonConvert.DeserializeObject<IEnumerable<TraktUserComment>>(jsonFile);

            userComments.Should().NotBeNull().And.HaveCount(5);

            var comments = userComments.ToArray();

            comments[0].Type.Should().Be(TraktObjectType.Movie);
            comments[0].Comment.Should().NotBeNull();
            comments[0].Movie.Should().NotBeNull();
            comments[0].Show.Should().BeNull();
            comments[0].Season.Should().BeNull();
            comments[0].Episode.Should().BeNull();
            comments[0].List.Should().BeNull();

            comments[1].Type.Should().Be(TraktObjectType.Show);
            comments[1].Comment.Should().NotBeNull();
            comments[1].Movie.Should().BeNull();
            comments[1].Show.Should().NotBeNull();
            comments[1].Season.Should().BeNull();
            comments[1].Episode.Should().BeNull();
            comments[1].List.Should().BeNull();

            comments[2].Type.Should().Be(TraktObjectType.Season);
            comments[2].Comment.Should().NotBeNull();
            comments[2].Movie.Should().BeNull();
            comments[2].Show.Should().NotBeNull();
            comments[2].Season.Should().NotBeNull();
            comments[2].Episode.Should().BeNull();
            comments[2].List.Should().BeNull();

            comments[3].Type.Should().Be(TraktObjectType.Episode);
            comments[3].Comment.Should().NotBeNull();
            comments[3].Movie.Should().BeNull();
            comments[3].Show.Should().NotBeNull();
            comments[3].Season.Should().BeNull();
            comments[3].Episode.Should().NotBeNull();
            comments[3].List.Should().BeNull();

            comments[4].Type.Should().Be(TraktObjectType.List);
            comments[4].Comment.Should().NotBeNull();
            comments[4].Movie.Should().BeNull();
            comments[4].Show.Should().BeNull();
            comments[4].Season.Should().BeNull();
            comments[4].Episode.Should().BeNull();
            comments[4].List.Should().NotBeNull();
        }
    }
}
