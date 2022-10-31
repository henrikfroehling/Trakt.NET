namespace TraktNet.Objects.Post.Tests.Checkins.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Checkins;
    using Xunit;

    [Category("Objects.Post.Checkins.Implementations")]
    public class TraktMovieCheckinPost_Tests
    {
        [Fact]
        public void Test_TraktMovieCheckinPost_Validate()
        {
            ITraktMovieCheckinPost movieCheckinPost = new TraktMovieCheckinPost();

            // Movie = null
            Action act = () => movieCheckinPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Movie Ids = null
            movieCheckinPost.Movie = new TraktMovie();
            act.Should().Throw<TraktPostValidationException>();

            // Movie IDs have no valid id
            movieCheckinPost.Movie = new TraktMovie { Ids = new TraktMovieIds() };
            act.Should().Throw<TraktPostValidationException>();

            // valid
            movieCheckinPost.Movie = new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } };
            act.Should().NotThrow();
        }
    }
}
