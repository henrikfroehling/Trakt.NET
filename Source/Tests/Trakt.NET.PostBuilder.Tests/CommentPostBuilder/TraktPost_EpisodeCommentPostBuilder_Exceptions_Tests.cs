namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithComment_ArgumentNullException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(null)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithComment_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.INVALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithEpisode_Episode_ArgumentNullException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(default(ITraktEpisode))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithEpisode_EpisodeIds_ArgumentNullException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(new TraktEpisode())
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(default(ITraktEpisodeIds))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithEpisode_EpisodeIds_ArgumentException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() })
                .Build();

            act.Should().Throw<ArgumentException>();

            act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(new TraktEpisodeIds())
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
