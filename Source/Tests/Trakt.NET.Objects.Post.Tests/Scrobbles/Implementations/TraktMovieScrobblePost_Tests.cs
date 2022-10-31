namespace TraktNet.Objects.Post.Tests.Scrobbles.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("Objects.Post.Scrobbles.Implementations")]
    public class TraktMovieScrobblePost_Tests
    {
        [Fact]
        public void Test_TraktMovieScrobblePost_Validate()
        {
            ITraktMovieScrobblePost movieScrobblePost = new TraktMovieScrobblePost();

            // Movie = null, Progress = 0
            Action act = () => movieScrobblePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Movie Ids = null, Progress = 0
            movieScrobblePost.Movie = new TraktMovie();
            act.Should().Throw<TraktPostValidationException>();

            // Movie IDs have no valid id, Progress = 0
            movieScrobblePost.Movie = new TraktMovie { Ids = new TraktMovieIds() };
            act.Should().Throw<TraktPostValidationException>();

            // Movie valid, Progress not valid
            movieScrobblePost.Movie = new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } };
            movieScrobblePost.Progress = -0.1f;
            act.Should().Throw<TraktPostValidationException>();

            // Movie valid, Progress not valid
            movieScrobblePost.Movie = new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } };
            movieScrobblePost.Progress = 100.1f;
            act.Should().Throw<TraktPostValidationException>();

            // valid
            movieScrobblePost.Movie = new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } };
            movieScrobblePost.Progress = 0;
            act.Should().NotThrow();

            // valid
            movieScrobblePost.Movie = new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } };
            movieScrobblePost.Progress = 100;
            act.Should().NotThrow();
        }
    }
}
