namespace TraktApiSharp.Tests.Objects.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows;
    using Utils;

    [TestClass]
    public class TraktShowCommentsTests
    {
        [TestMethod]
        public void TestTraktShowCommentsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var showComments = JsonConvert.DeserializeObject<IEnumerable<TraktShowComment>>(jsonFile);

            showComments.Should().NotBeNull();
            showComments.Should().HaveCount(2);

            var comments = showComments.ToArray();

            comments[0].Id.Should().Be(76498);
            comments[0].Comment.Should().Be("empiezo a verla de nuevo,esta estupenda");
            comments[0].Spoiler.Should().BeFalse();
            comments[0].Review.Should().BeFalse();
            comments[0].ParentId.Should().Be(0);
            comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-03-28T22:31:46Z").ToUniversalTime());
            comments[0].UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T14:12:05Z").ToUniversalTime());
            comments[0].Replies.Should().Be(1);
            comments[0].Likes.Should().Be(2);
            comments[0].UserRating.Should().Be(9.0f);
            comments[0].User.Should().NotBeNull();

            comments[1].Id.Should().Be(76245);
            comments[1].Comment.Should().Be("I still don't get it!");
            comments[1].Spoiler.Should().BeFalse();
            comments[1].Review.Should().BeTrue();
            comments[1].ParentId.Should().Be(1);
            comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-03-26T23:21:20Z").ToUniversalTime());
            comments[1].UpdatedAt.Should().Be(DateTime.Parse("2016-03-27T09:11:31Z").ToUniversalTime());
            comments[1].Replies.Should().Be(2);
            comments[1].Likes.Should().Be(3);
            comments[1].UserRating.Should().Be(8.3f);
            comments[1].User.Should().NotBeNull();
        }
    }
}
