namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeScrobblePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_Episode_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_EpisodeIds_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktEpisode())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_EpisodeIds_ArgumentException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_Show_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(null, 0, 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_ShowIds_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktShow(), 0, 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_ShowIds_ArgumentException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds() }, 0, 1)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_SeasonNumber_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, -1, 1)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithEpisode_EpisodeNumber_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, 0)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithProgress_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithProgress(-0.1f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktPost.NewEpisodeScrobblePost()
                .WithProgress(100.1f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithAppVersion_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithAppVersion(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_WithAppDate_ArgumentNullException()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost()
                .WithAppDate(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
