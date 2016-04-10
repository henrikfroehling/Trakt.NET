namespace TraktApiSharp.Tests.Objects.Shows.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Shows.Seasons;
    using Utils;

    [TestClass]
    public class TraktSeasonCommentsTests
    {
        [TestMethod]
        public void TestTraktSeasonCommentsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Shows\Seasons\Single\SeasonComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var seasonComments = JsonConvert.DeserializeObject<IEnumerable<TraktSeasonComment>>(jsonFile);

            seasonComments.Should().NotBeNull();
            seasonComments.Should().HaveCount(3);

            var comments = seasonComments.ToArray();

            comments[0].Id.Should().Be(65637);
            comments[0].Comment.Should().Be("loved the first season, bring on the dragons!!");
            comments[0].Spoiler.Should().BeTrue();
            comments[0].Review.Should().BeFalse();
            comments[0].ParentId.Should().Be(0);
            comments[0].CreatedAt.Should().Be(DateTime.Parse("2015-12-20T19:16:55Z").ToUniversalTime());
            comments[0].Replies.Should().Be(2);
            comments[0].Likes.Should().Be(3);
            comments[0].UserRating.Should().Be(10.0m);
            comments[0].User.Should().NotBeNull();

            comments[1].Id.Should().Be(58396);
            comments[1].Comment.Should().Be("Hooked from the first episode.");
            comments[1].Spoiler.Should().BeFalse();
            comments[1].Review.Should().BeFalse();
            comments[1].ParentId.Should().Be(1);
            comments[1].CreatedAt.Should().Be(DateTime.Parse("2015-10-07T15:16:11Z").ToUniversalTime());
            comments[1].Replies.Should().Be(3);
            comments[1].Likes.Should().Be(4);
            comments[1].UserRating.Should().NotHaveValue();
            comments[1].User.Should().NotBeNull();

            comments[2].Id.Should().Be(51184);
            comments[2].Comment.Should().Be("Great opening season but still overly brutal from time to time (as are the books). Because of its fast pace the TV series is not as nerve-grating as the books are: here one's empathy with the protagonists that suffer and die is short lived because the plot is moving forward very fast while when reading the books one suffers endlessly when George R. R. Martin decides to kill off (yet) another of the good guys he built up painstakingly or when he lets the evil ones live and flourish even though moral dictates that they have to suffer or die.");
            comments[2].Spoiler.Should().BeFalse();
            comments[2].Review.Should().BeFalse();
            comments[2].ParentId.Should().Be(0);
            comments[2].CreatedAt.Should().Be(DateTime.Parse("2015-07-31T12:30:12Z").ToUniversalTime());
            comments[2].Replies.Should().Be(0);
            comments[2].Likes.Should().Be(0);
            comments[2].UserRating.Should().Be(8.0m);
            comments[2].User.Should().NotBeNull();
        }
    }
}
