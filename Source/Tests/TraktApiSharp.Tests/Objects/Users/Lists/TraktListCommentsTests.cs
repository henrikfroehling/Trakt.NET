namespace TraktApiSharp.Tests.Objects.Users.Lists
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Utils;

    [TestClass]
    public class TraktListCommentsTests
    {
        [TestMethod]
        public void TestTraktListCommentsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Users\Lists\ListComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var listComments = JsonConvert.DeserializeObject<IEnumerable<TraktListComment>>(jsonFile);

            listComments.Should().NotBeNull();
            listComments.Should().HaveCount(2);

            var comments = listComments.ToArray();

            comments[0].Id.Should().Be(8);
            comments[0].Comment.Should().Be("Can't wait to watch everything on this epic list!");
            comments[0].Spoiler.Should().BeFalse();
            comments[0].Review.Should().BeFalse();
            comments[0].ParentId.Should().Be(0);
            comments[0].CreatedAt.Should().Be(DateTime.Parse("2011-03-25T22:35:17.000Z").ToUniversalTime());
            comments[0].Replies.Should().Be(3);
            comments[0].Likes.Should().Be(0);
            comments[0].UserRating.Should().NotHaveValue();
            comments[0].User.Should().NotBeNull();

            comments[1].Id.Should().Be(11);
            comments[1].Comment.Should().Be("bla bla bla");
            comments[1].Spoiler.Should().BeFalse();
            comments[1].Review.Should().BeTrue();
            comments[1].ParentId.Should().Be(1);
            comments[1].CreatedAt.Should().Be(DateTime.Parse("2011-04-17T22:35:17.000Z").ToUniversalTime());
            comments[1].Replies.Should().Be(0);
            comments[1].Likes.Should().Be(2);
            comments[1].UserRating.Should().Be(9.0m);
            comments[1].User.Should().NotBeNull();
        }
    }
}
