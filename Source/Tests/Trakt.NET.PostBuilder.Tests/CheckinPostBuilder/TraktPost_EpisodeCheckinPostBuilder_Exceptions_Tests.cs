namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeCheckinPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_Episode_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(default(ITraktEpisode))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_EpisodeIds_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktEpisode())
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(default(ITraktEpisodeIds))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_EpisodeIds_ArgumentException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() })
                .Build();

            act.Should().Throw<ArgumentException>();

            act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktEpisodeIds())
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_Show_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(null, 0, 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_ShowIds_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow(), 0, 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_ShowIds_ArgumentException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds() }, 0, 1)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_SeasonNumber_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, -1, 1)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_EpisodeNumber_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, 0)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_Show_WithAbsoluteEpisodeNumber_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(null, 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_ShowIds_WithAbsoluteEpisodeNumber_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow(), 1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_ShowIds_WithAbsoluteEpisodeNumber_ArgumentException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds() }, 1)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithEpisode_AbsoluteEpisodeNumber_ArgumentOutOfRangeException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0)
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithMessage_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithMessage(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithAppVersion_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithAppVersion(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithAppDate_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithAppDate(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithFoursquareVenueId_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithFoursquareVenueId(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithFoursquareVenueName_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithFoursquareVenueName(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost()
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
