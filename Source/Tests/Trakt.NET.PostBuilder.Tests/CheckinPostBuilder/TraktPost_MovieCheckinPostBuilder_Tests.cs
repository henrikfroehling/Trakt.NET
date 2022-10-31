namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_MovieCheckinPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Empty_Build()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_Message()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_AppVersion()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_AppDate()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_FoursquareVenueId()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_FoursquareVenueName()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            movieCheckinPost.Sharing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Checkin_Movie_Sharing()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().BeNull();
            movieCheckinPost.AppVersion.Should().BeNull();
            movieCheckinPost.AppDate.Should().BeNull();
            movieCheckinPost.FoursquareVenueId.Should().BeNull();
            movieCheckinPost.FoursquareVenueName.Should().BeNull();
            movieCheckinPost.Sharing.Should().NotBeNull();
            movieCheckinPost.Sharing.Apple.Should().BeTrue();
            movieCheckinPost.Sharing.Facebook.Should().BeTrue();
            movieCheckinPost.Sharing.Google.Should().BeTrue();
            movieCheckinPost.Sharing.Medium.Should().BeTrue();
            movieCheckinPost.Sharing.Slack.Should().BeTrue();
            movieCheckinPost.Sharing.Tumblr.Should().BeTrue();
            movieCheckinPost.Sharing.Twitter.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_Complete()
        {
            ITraktMovieCheckinPost movieCheckinPost = TraktPost.NewMovieCheckinPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithMessage(TraktPost_Tests_Common_Data.MESSAGE)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .WithFoursquareVenueId(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID)
                .WithFoursquareVenueName(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            movieCheckinPost.Should().NotBeNull();
            movieCheckinPost.Movie.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Should().NotBeNull();
            movieCheckinPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCheckinPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCheckinPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCheckinPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCheckinPost.Message.Should().Be(TraktPost_Tests_Common_Data.MESSAGE);
            movieCheckinPost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            movieCheckinPost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
            movieCheckinPost.FoursquareVenueId.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_ID);
            movieCheckinPost.FoursquareVenueName.Should().Be(TraktPost_Tests_Common_Data.FOURSQUARE_VENUE_NAME);
            movieCheckinPost.Sharing.Should().NotBeNull();
            movieCheckinPost.Sharing.Apple.Should().BeTrue();
            movieCheckinPost.Sharing.Facebook.Should().BeTrue();
            movieCheckinPost.Sharing.Google.Should().BeTrue();
            movieCheckinPost.Sharing.Medium.Should().BeTrue();
            movieCheckinPost.Sharing.Slack.Should().BeTrue();
            movieCheckinPost.Sharing.Tumblr.Should().BeTrue();
            movieCheckinPost.Sharing.Twitter.Should().BeTrue();
        }
    }
}
