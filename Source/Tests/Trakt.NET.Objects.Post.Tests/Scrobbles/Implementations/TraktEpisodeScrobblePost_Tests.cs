namespace TraktNet.Objects.Post.Tests.Scrobbles.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("Objects.Post.Scrobbles.Implementations")]
    public class TraktEpisodeScrobblePost_Tests
    {
        [Fact]
        public void Test_TraktEpisodeScrobblePost_Validate()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = new TraktEpisodeScrobblePost();

            // Episode = null, Show = null, Progress = 0
            Action act = () => episodeScrobblePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = null, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids have no valid id, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds() };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show = null, Episode Ids = valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            act.Should().NotThrow();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            episodeScrobblePost.Progress = -0.1f;
            act.Should().Throw<TraktPostValidationException>();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 100.1f;
            act.Should().Throw<TraktPostValidationException>();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 0;
            act.Should().NotThrow();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 100;
            act.Should().NotThrow();

            // Episode != null, Show != null, Show Ids = null, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            episodeScrobblePost.Show = new TraktShow();
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids have no valid id, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode();
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds() };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Season Number not valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = -1, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Number not valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 0 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().Throw<TraktPostValidationException>();

            // Episode != null, Show != null, Show Ids = valid, Episode Numbers are valid, Progress = 0
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            act.Should().NotThrow();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            episodeScrobblePost.Progress = -0.1f;
            act.Should().Throw<TraktPostValidationException>();

            // Episode valid, Progress not valid
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 100.1f;
            act.Should().Throw<TraktPostValidationException>();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 0;
            act.Should().NotThrow();

            // valid
            episodeScrobblePost.Episode = new TraktEpisode { SeasonNumber = 0, Number = 1 };
            episodeScrobblePost.Show = new TraktShow { Ids = new TraktShowIds { Trakt = 1 } };
            episodeScrobblePost.Progress = 100;
            act.Should().NotThrow();
        }
    }
}
