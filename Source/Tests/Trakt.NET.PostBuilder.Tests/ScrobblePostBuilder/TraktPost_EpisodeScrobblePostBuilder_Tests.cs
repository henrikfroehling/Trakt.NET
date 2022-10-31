namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeScrobblePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Empty_Build()
        {
            Func<ITraktEpisodeScrobblePost> act = () => TraktPost.NewEpisodeScrobblePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeScrobblePost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeScrobblePost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeScrobblePost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeScrobblePost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeScrobblePost.Episode.SeasonNumber.Should().BeNull();
            episodeScrobblePost.Episode.Number.Should().BeNull();
            episodeScrobblePost.Show.Should().BeNull();
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().BeNull();
            episodeScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode_WithShow()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().BeNull();
            episodeScrobblePost.Episode.SeasonNumber.Should().Be(1);
            episodeScrobblePost.Episode.Number.Should().Be(1);
            episodeScrobblePost.Show.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeScrobblePost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeScrobblePost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeScrobblePost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeScrobblePost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().BeNull();
            episodeScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode_AppVersion()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeScrobblePost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeScrobblePost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeScrobblePost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeScrobblePost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeScrobblePost.Episode.SeasonNumber.Should().BeNull();
            episodeScrobblePost.Episode.Number.Should().BeNull();
            episodeScrobblePost.Show.Should().BeNull();
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode_WithShow_AppVersion()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().BeNull();
            episodeScrobblePost.Episode.SeasonNumber.Should().Be(1);
            episodeScrobblePost.Episode.Number.Should().Be(1);
            episodeScrobblePost.Show.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeScrobblePost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeScrobblePost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeScrobblePost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeScrobblePost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode_AppDate()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeScrobblePost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeScrobblePost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeScrobblePost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeScrobblePost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeScrobblePost.Episode.SeasonNumber.Should().BeNull();
            episodeScrobblePost.Episode.Number.Should().BeNull();
            episodeScrobblePost.Show.Should().BeNull();
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().BeNull();
            episodeScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Scrobble_Episode_WithShow_AppDate()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().BeNull();
            episodeScrobblePost.Episode.SeasonNumber.Should().Be(1);
            episodeScrobblePost.Episode.Number.Should().Be(1);
            episodeScrobblePost.Show.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeScrobblePost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeScrobblePost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeScrobblePost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeScrobblePost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().BeNull();
            episodeScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Complete()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeScrobblePost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeScrobblePost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeScrobblePost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeScrobblePost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeScrobblePost.Episode.SeasonNumber.Should().BeNull();
            episodeScrobblePost.Episode.Number.Should().BeNull();
            episodeScrobblePost.Show.Should().BeNull();
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }

        [Fact]
        public void Test_TraktPost_EpisodeScrobblePostBuilder_Complete_WithShow()
        {
            ITraktEpisodeScrobblePost episodeScrobblePost = TraktPost.NewEpisodeScrobblePost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeScrobblePost.Should().NotBeNull();
            episodeScrobblePost.Episode.Should().NotBeNull();
            episodeScrobblePost.Episode.Ids.Should().BeNull();
            episodeScrobblePost.Episode.SeasonNumber.Should().Be(1);
            episodeScrobblePost.Episode.Number.Should().Be(1);
            episodeScrobblePost.Show.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Should().NotBeNull();
            episodeScrobblePost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeScrobblePost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeScrobblePost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeScrobblePost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeScrobblePost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            episodeScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }
    }
}
