namespace TraktApiSharp.Tests.Objects.Shows.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using Utils;

    [TestClass]
    public class TraktEpisodeCommentsTests
    {
        [TestMethod]
        public void TestTraktEpisodeCommentsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\Episodes\EpisodeComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var episodeComments = JsonConvert.DeserializeObject<IEnumerable<TraktEpisodeComment>>(jsonFile);

            episodeComments.Should().NotBeNull();
            episodeComments.Should().HaveCount(4);

            var comments = episodeComments.ToArray();

            comments[0].Id.Should().Be(62055);
            comments[0].Comment.Should().Be("Such an amazing tv show");
            comments[0].Spoiler.Should().BeFalse();
            comments[0].Review.Should().BeFalse();
            comments[0].ParentId.Should().Be(0);
            comments[0].CreatedAt.Should().Be(DateTime.Parse("2015-11-12T22:28:30Z").ToUniversalTime());
            comments[0].Replies.Should().Be(2);
            comments[0].Likes.Should().Be(3);
            comments[0].UserRating.Should().Be(10.0m);
            comments[0].User.Should().NotBeNull();

            comments[1].Id.Should().Be(58403);
            comments[1].Comment.Should().Be("Great intro to the GoT universe.");
            comments[1].Spoiler.Should().BeFalse();
            comments[1].Review.Should().BeFalse();
            comments[1].ParentId.Should().Be(1);
            comments[1].CreatedAt.Should().Be(DateTime.Parse("2015-10-07T16:15:13Z").ToUniversalTime());
            comments[1].Replies.Should().Be(3);
            comments[1].Likes.Should().Be(4);
            comments[1].UserRating.Should().NotHaveValue();
            comments[1].User.Should().NotBeNull();

            comments[2].Id.Should().Be(44743);
            comments[2].Comment.Should().Be("Let's give it a try to this show");
            comments[2].Spoiler.Should().BeFalse();
            comments[2].Review.Should().BeFalse();
            comments[2].ParentId.Should().Be(0);
            comments[2].CreatedAt.Should().Be(DateTime.Parse("2015-05-25T18:34:22Z").ToUniversalTime());
            comments[2].Replies.Should().Be(0);
            comments[2].Likes.Should().Be(1);
            comments[2].UserRating.Should().Be(9.0m);
            comments[2].User.Should().NotBeNull();

            comments[3].Id.Should().Be(44380);
            comments[3].Comment.Should().Be("Love this amazing tv show.");
            comments[3].Spoiler.Should().BeFalse();
            comments[3].Review.Should().BeFalse();
            comments[3].ParentId.Should().Be(0);
            comments[3].CreatedAt.Should().Be(DateTime.Parse("2015-05-22T07:15:34Z").ToUniversalTime());
            comments[3].Replies.Should().Be(0);
            comments[3].Likes.Should().Be(0);
            comments[3].UserRating.Should().NotHaveValue();
            comments[3].User.Should().NotBeNull();
        }
    }
}
