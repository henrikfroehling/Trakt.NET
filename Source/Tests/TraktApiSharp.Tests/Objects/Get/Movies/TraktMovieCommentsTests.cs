namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieCommentsTests
    {
        [TestMethod]
        public void TestTraktMovieCommentsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieComments = JsonConvert.DeserializeObject<IEnumerable<TraktMovieComment>>(jsonFile);

            movieComments.Should().NotBeNull();
            movieComments.Should().HaveCount(2);

            var comments = movieComments.ToArray();

            comments[0].Id.Should().Be(77543);
            comments[0].Comment.Should().Be("Fantastic excellent photography and film");
            comments[0].Spoiler.Should().BeFalse();
            comments[0].Review.Should().BeTrue();
            comments[0].ParentId.Should().Be(1);
            comments[0].CreatedAt.Should().Be(DateTime.Parse("2016-04-05T21:07:16Z").ToUniversalTime());
            comments[0].Replies.Should().Be(2);
            comments[0].Likes.Should().Be(3);
            comments[0].UserRating.Should().Be(9.0f);
            comments[0].User.Should().NotBeNull();

            comments[1].Id.Should().Be(77164);
            comments[1].Comment.Should().Be("Nothing over exciting. Just a fantasy with elements of comedy. Even Ford didn't help. ");
            comments[1].Spoiler.Should().BeFalse();
            comments[1].Review.Should().BeFalse();
            comments[1].ParentId.Should().Be(0);
            comments[1].CreatedAt.Should().Be(DateTime.Parse("2016-04-02T23:38:12Z").ToUniversalTime());
            comments[1].Replies.Should().Be(0);
            comments[1].Likes.Should().Be(0);
            comments[1].UserRating.Should().Be(5.0f);
            comments[1].User.Should().NotBeNull();
        }
    }
}
