namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_ShowCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_Empty_Build()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost().Build();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_Comment_Show()
        {
            ITraktShowCommentPost showCommentPost = TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            showCommentPost.Should().NotBeNull();
            showCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            showCommentPost.Show.Should().NotBeNull();
            showCommentPost.Show.Ids.Should().NotBeNull();
            showCommentPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            showCommentPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            showCommentPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            showCommentPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            showCommentPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            showCommentPost.Sharing.Should().BeNull();
            showCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_Comment_Show_Sharing()
        {
            ITraktShowCommentPost showCommentPost = TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            showCommentPost.Should().NotBeNull();
            showCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            showCommentPost.Show.Should().NotBeNull();
            showCommentPost.Show.Ids.Should().NotBeNull();
            showCommentPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            showCommentPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            showCommentPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            showCommentPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            showCommentPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            showCommentPost.Sharing.Should().NotBeNull();
            showCommentPost.Sharing.Apple.Should().BeTrue();
            showCommentPost.Sharing.Facebook.Should().BeTrue();
            showCommentPost.Sharing.Google.Should().BeTrue();
            showCommentPost.Sharing.Medium.Should().BeTrue();
            showCommentPost.Sharing.Slack.Should().BeTrue();
            showCommentPost.Sharing.Tumblr.Should().BeTrue();
            showCommentPost.Sharing.Twitter.Should().BeTrue();
            showCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_Comment_Show_Spoiler()
        {
            ITraktShowCommentPost showCommentPost = TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .WithSpoiler(true)
                .Build();

            showCommentPost.Should().NotBeNull();
            showCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            showCommentPost.Show.Should().NotBeNull();
            showCommentPost.Show.Ids.Should().NotBeNull();
            showCommentPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            showCommentPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            showCommentPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            showCommentPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            showCommentPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            showCommentPost.Sharing.Should().BeNull();
            showCommentPost.Spoiler.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_Complete()
        {
            ITraktShowCommentPost showCommentPost = TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .WithSpoiler(true)
                .Build();

            showCommentPost.Should().NotBeNull();
            showCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            showCommentPost.Show.Should().NotBeNull();
            showCommentPost.Show.Ids.Should().NotBeNull();
            showCommentPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            showCommentPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            showCommentPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            showCommentPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            showCommentPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            showCommentPost.Sharing.Should().NotBeNull();
            showCommentPost.Sharing.Apple.Should().BeTrue();
            showCommentPost.Sharing.Facebook.Should().BeTrue();
            showCommentPost.Sharing.Google.Should().BeTrue();
            showCommentPost.Sharing.Medium.Should().BeTrue();
            showCommentPost.Sharing.Slack.Should().BeTrue();
            showCommentPost.Sharing.Tumblr.Should().BeTrue();
            showCommentPost.Sharing.Twitter.Should().BeTrue();
            showCommentPost.Spoiler.Should().BeTrue();
        }
    }
}
