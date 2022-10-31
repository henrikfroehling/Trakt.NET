namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_MovieCheckinPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithMovie_Movie_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithMovie(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithMovie_MovieIds_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithMovie(new TraktMovie())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithMovie_MovieIds_ArgumentException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithMovie(new TraktMovie { Ids = new TraktMovieIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithMessage_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithMessage(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithAppVersion_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithAppVersion(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithAppDate_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithAppDate(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithFoursquareVenueId_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithFoursquareVenueId(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithFoursquareVenueName_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithFoursquareVenueName(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCheckinPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktMovieCheckinPost> act = () => TraktPost.NewMovieCheckinPost()
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
