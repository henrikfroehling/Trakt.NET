namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SeasonCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_Empty_Build()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost().Build();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_Comment_Season()
        {
            ITraktSeasonCommentPost seasonCommentPost = TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            seasonCommentPost.Should().NotBeNull();
            seasonCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            seasonCommentPost.Season.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            seasonCommentPost.Season.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            seasonCommentPost.Season.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            seasonCommentPost.Season.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            seasonCommentPost.Sharing.Should().BeNull();
            seasonCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_Comment_Season_Sharing()
        {
            ITraktSeasonCommentPost seasonCommentPost = TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            seasonCommentPost.Should().NotBeNull();
            seasonCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            seasonCommentPost.Season.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            seasonCommentPost.Season.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            seasonCommentPost.Season.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            seasonCommentPost.Season.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            seasonCommentPost.Sharing.Should().NotBeNull();
            seasonCommentPost.Sharing.Apple.Should().BeTrue();
            seasonCommentPost.Sharing.Facebook.Should().BeTrue();
            seasonCommentPost.Sharing.Google.Should().BeTrue();
            seasonCommentPost.Sharing.Medium.Should().BeTrue();
            seasonCommentPost.Sharing.Slack.Should().BeTrue();
            seasonCommentPost.Sharing.Tumblr.Should().BeTrue();
            seasonCommentPost.Sharing.Twitter.Should().BeTrue();
            seasonCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_Comment_Season_Spoiler()
        {
            ITraktSeasonCommentPost seasonCommentPost = TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .WithSpoiler(true)
                .Build();

            seasonCommentPost.Should().NotBeNull();
            seasonCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            seasonCommentPost.Season.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            seasonCommentPost.Season.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            seasonCommentPost.Season.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            seasonCommentPost.Season.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            seasonCommentPost.Sharing.Should().BeNull();
            seasonCommentPost.Spoiler.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_Complete()
        {
            ITraktSeasonCommentPost seasonCommentPost = TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .WithSpoiler(true)
                .Build();

            seasonCommentPost.Should().NotBeNull();
            seasonCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            seasonCommentPost.Season.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Should().NotBeNull();
            seasonCommentPost.Season.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            seasonCommentPost.Season.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            seasonCommentPost.Season.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            seasonCommentPost.Season.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            seasonCommentPost.Sharing.Should().NotBeNull();
            seasonCommentPost.Sharing.Apple.Should().BeTrue();
            seasonCommentPost.Sharing.Facebook.Should().BeTrue();
            seasonCommentPost.Sharing.Google.Should().BeTrue();
            seasonCommentPost.Sharing.Medium.Should().BeTrue();
            seasonCommentPost.Sharing.Slack.Should().BeTrue();
            seasonCommentPost.Sharing.Tumblr.Should().BeTrue();
            seasonCommentPost.Sharing.Twitter.Should().BeTrue();
            seasonCommentPost.Spoiler.Should().BeTrue();
        }
    }
}
