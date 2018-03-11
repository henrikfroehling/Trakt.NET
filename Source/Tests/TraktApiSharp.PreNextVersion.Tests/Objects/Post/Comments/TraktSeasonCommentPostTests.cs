namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    //using Newtonsoft.Json;
    //using TraktApiSharp.Objects.Basic.Implementations;
    //using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Post.Comments.Implementations;

    [TestClass]
    public class TraktSeasonCommentPostTests
    {
        [TestMethod]
        public void TestTraktSeasonCommentPostDefaultConstructor()
        {
            var seasonComment = new TraktSeasonCommentPost();

            seasonComment.Comment.Should().BeNullOrEmpty();
            seasonComment.Spoiler.Should().NotHaveValue();
            seasonComment.Sharing.Should().BeNull();
            seasonComment.Season.Should().BeNull();
        }

        // TODO Fix test with custom json writer
        //[TestMethod]
        //public void TestTraktSeasonCommentPostWriteJson()
        //{
        //    var comment = "this is a comment";
        //    var spoiler = false;
        //    var sharing = new TraktSharing { Facebook = true, Twitter = false, Tumblr = false };

        //    var seasonTraktId = 16U;

        //    var season = new TraktSeason { Ids = new TraktSeasonIds { Trakt = seasonTraktId } };

        //    var seasonComment = new TraktSeasonCommentPost
        //    {
        //        Comment = comment,
        //        Spoiler = spoiler,
        //        Sharing = sharing,
        //        Season = season
        //    };

        //    var strJson = JsonConvert.SerializeObject(seasonComment);

        //    strJson.Should().NotBeNullOrEmpty();

        //    var seasonCommentFromJson = JsonConvert.DeserializeObject<TraktSeasonCommentPost>(strJson);

        //    seasonCommentFromJson.Should().NotBeNull();
        //    seasonCommentFromJson.Comment.Should().Be(comment);
        //    seasonCommentFromJson.Spoiler.Should().Be(spoiler);
        //    seasonCommentFromJson.Sharing.Should().NotBeNull();
        //    seasonCommentFromJson.Sharing.Facebook.Should().BeTrue();
        //    seasonCommentFromJson.Sharing.Twitter.Should().BeFalse();
        //    seasonCommentFromJson.Sharing.Tumblr.Should().BeFalse();

        //    seasonCommentFromJson.Season.Should().NotBeNull();
        //    seasonCommentFromJson.Season.Ids.Should().NotBeNull();
        //    seasonCommentFromJson.Season.Ids.Trakt.Should().Be(seasonTraktId);
        //}
    }
}
