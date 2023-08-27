namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SeasonCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithComment_ArgumentNullException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(null)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithComment_ArgumentOutOfRangeException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.INVALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithSeason_Season_ArgumentNullException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(default(ITraktSeason))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithSeason_SeasonIds_ArgumentNullException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(new TraktSeason())
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(default(ITraktSeasonIds))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithSeason_SeasonIds_ArgumentException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(new TraktSeason { Ids = new TraktSeasonIds() })
                .Build();

            act.Should().Throw<ArgumentException>();

            act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(new TraktSeasonIds())
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_SeasonCommentPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktSeasonCommentPost> act = () => TraktPost.NewSeasonCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
