namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("Objects.Post.Comments.Implementations")]
    public class TraktEpisodeCommentPost_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCommentPost_Validate()
        {
            ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost();

            // Comment = null
            Action act = () => episodeCommentPost.Validate();
            act.Should().Throw<ArgumentNullException>();

            // Comment = less than five words
            episodeCommentPost.Comment = "one two three four";
            act.Should().Throw<ArgumentOutOfRangeException>();

            // Episode = null
            episodeCommentPost.Comment = "one two three four five";
            act.Should().Throw<ArgumentNullException>();

            // valid
            episodeCommentPost.Episode = new TraktEpisode();
            act.Should().NotThrow();
        }
    }
}
