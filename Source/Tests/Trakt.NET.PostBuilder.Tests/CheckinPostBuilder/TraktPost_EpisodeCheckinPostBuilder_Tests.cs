namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_EpisodeCheckinPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Empty_Build()
        {
            Func<ITraktEpisodeCheckinPost> act = () => TraktPost.NewEpisodeCheckinPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_EpisodeIds()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_Message()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_AppVersion()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_AppVersion()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_AppVersion()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_AppDate()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_FoursquareVenueId()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_FoursquareVenueName()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Checkin_Episode_WithShow_WithAbsoluteEpisodeNumber_Sharing()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().BeNull();
            episodeCheckinPost.AppVersion.Should().BeNull();
            episodeCheckinPost.AppDate.Should().BeNull();
            episodeCheckinPost.FoursquareVenueId.Should().BeNull();
            episodeCheckinPost.FoursquareVenueName.Should().BeNull();
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Complete()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            episodeCheckinPost.Episode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            episodeCheckinPost.Episode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            episodeCheckinPost.Episode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            episodeCheckinPost.Episode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().BeNull();
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Complete_WithShow()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1, 1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().Be(1);
            episodeCheckinPost.Episode.Number.Should().Be(1);
            episodeCheckinPost.Episode.NumberAbsolute.Should().BeNull();
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_EpisodeCheckinPostBuilder_Complete_WithShow_WithAbsoluteEpisodeNumber()
        {
            ITraktEpisodeCheckinPost episodeCheckinPost = TraktPost.NewEpisodeCheckinPost()
                .WithEpisode(TraktPost_Tests_Common_Data.SHOW_1, 1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            episodeCheckinPost.Should().NotBeNull();
            episodeCheckinPost.Episode.Should().NotBeNull();
            episodeCheckinPost.Episode.Ids.Should().BeNull();
            episodeCheckinPost.Episode.SeasonNumber.Should().BeNull();
            episodeCheckinPost.Episode.Number.Should().BeNull();
            episodeCheckinPost.Episode.NumberAbsolute.Should().Be(1);
            episodeCheckinPost.Show.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Should().NotBeNull();
            episodeCheckinPost.Show.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            episodeCheckinPost.Show.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            episodeCheckinPost.Show.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tvdb);
            episodeCheckinPost.Show.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.TvRage);
            episodeCheckinPost.Show.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            episodeCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            episodeCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            episodeCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            episodeCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            episodeCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            episodeCheckinPost.Sharing.Should().NotBeNull();
            episodeCheckinPost.Sharing.Apple.Should().BeTrue();
            episodeCheckinPost.Sharing.Facebook.Should().BeTrue();
            episodeCheckinPost.Sharing.Google.Should().BeTrue();
            episodeCheckinPost.Sharing.Medium.Should().BeTrue();
            episodeCheckinPost.Sharing.Slack.Should().BeTrue();
            episodeCheckinPost.Sharing.Tumblr.Should().BeTrue();
            episodeCheckinPost.Sharing.Twitter.Should().BeTrue();
        }
    }
}
