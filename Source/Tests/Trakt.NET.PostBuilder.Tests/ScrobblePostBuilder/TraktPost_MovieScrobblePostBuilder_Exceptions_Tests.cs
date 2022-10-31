namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_MovieScrobblePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithMovie_Movie_ArgumentNullException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithMovie(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithMovie_MovieIds_ArgumentNullException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithMovie(new TraktMovie())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithMovie_MovieIds_ArgumentException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithMovie(new TraktMovie { Ids = new TraktMovieIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithProgress_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithProgress(-0.1f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => TraktPost.NewMovieScrobblePost()
                .WithProgress(100.1f)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithAppVersion_ArgumentNullException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithAppVersion(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_WithAppDate_ArgumentNullException()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost()
                .WithAppDate(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
