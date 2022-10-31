namespace TraktNet.Objects.Post.Tests.Checkins.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [TestCategory("Objects.Post.Checkins.Implementations")]
    public class TraktEpisodeCheckinPost_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCheckinPost_Validate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost();

            // Episode = null, Show = null
            Action act = () => episodeCheckinPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = null
            episodeCheckinPost.Episode = new TraktEpisode();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids have no valid id
            episodeCheckinPost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds() };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = valid
            episodeCheckinPost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            act.Should().NotThrow();

            // Episode != null, Show != null, Show Ids = null
            episodeCheckinPost.Episode = new TraktEpisode();
            episodeCheckinPost.Show = new TraktShow();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids have no valid id
            episodeCheckinPost.Episode = new TraktEpisode();
            episodeCheckinPost.Show = new TraktShow { Ids = new TraktShowIds() };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Season Number not valid
            episodeCheckinPost.Episode = new TraktEpisode { SeasonNumber = -1, Number = 1 };
            episodeCheckinPost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Number not valid
            episodeCheckinPost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 0 };
            episodeCheckinPost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Numbers are valid
            episodeCheckinPost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeCheckinPost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().NotThrow();
        }
    }
}
