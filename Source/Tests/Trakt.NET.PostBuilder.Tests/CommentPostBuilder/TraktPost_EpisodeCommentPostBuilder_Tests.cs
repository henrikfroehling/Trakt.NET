namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_Empty_Build()
        {
            Func<ITraktEpisodeCommentPost> act = () => TraktPost.NewEpisodeCommentPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_Comment_Episode()
        {
            ITraktEpisodeCommentPost episodeCommentPost = TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            episodeCommentPost.Should().NotBeNull();
            episodeCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            episodeCommentPost.Episode.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCommentPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCommentPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCommentPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCommentPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCommentPost.Sharing.Should().BeNull();
            episodeCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_Comment_Episode_Sharing()
        {
            ITraktEpisodeCommentPost episodeCommentPost = TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCommentPost.Should().NotBeNull();
            episodeCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            episodeCommentPost.Episode.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCommentPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCommentPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCommentPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCommentPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCommentPost.Sharing.Should().NotBeNull();
            episodeCommentPost.Sharing.Apple.Should().BeTrue();
            episodeCommentPost.Sharing.Facebook.Should().BeTrue();
            episodeCommentPost.Sharing.Google.Should().BeTrue();
            episodeCommentPost.Sharing.Medium.Should().BeTrue();
            episodeCommentPost.Sharing.Slack.Should().BeTrue();
            episodeCommentPost.Sharing.Tumblr.Should().BeTrue();
            episodeCommentPost.Sharing.Twitter.Should().BeTrue();
            episodeCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_Comment_Episode_Spoiler()
        {
            ITraktEpisodeCommentPost episodeCommentPost = TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithSpoiler(true)
                .Build();

            episodeCommentPost.Should().NotBeNull();
            episodeCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            episodeCommentPost.Episode.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCommentPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCommentPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCommentPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCommentPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCommentPost.Sharing.Should().BeNull();
            episodeCommentPost.Spoiler.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCommentPostBuilder_Complete()
        {
            ITraktEpisodeCommentPost episodeCommentPost = TraktPost.NewEpisodeCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .WithSpoiler(true)
                .Build();

            episodeCommentPost.Should().NotBeNull();
            episodeCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            episodeCommentPost.Episode.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Should().NotBeNull();
            episodeCommentPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCommentPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCommentPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCommentPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCommentPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCommentPost.Sharing.Should().NotBeNull();
            episodeCommentPost.Sharing.Apple.Should().BeTrue();
            episodeCommentPost.Sharing.Facebook.Should().BeTrue();
            episodeCommentPost.Sharing.Google.Should().BeTrue();
            episodeCommentPost.Sharing.Medium.Should().BeTrue();
            episodeCommentPost.Sharing.Slack.Should().BeTrue();
            episodeCommentPost.Sharing.Tumblr.Should().BeTrue();
            episodeCommentPost.Sharing.Twitter.Should().BeTrue();
            episodeCommentPost.Spoiler.Should().BeTrue();
        }
    }
}
