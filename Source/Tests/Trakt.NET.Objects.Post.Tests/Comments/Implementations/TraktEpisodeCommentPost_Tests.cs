namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("Objects.Post.Comments.Implementations")]
    public class TraktEpisodeCommentPost_Tests
    {
        [Fact]
        public void Test_TraktEpisodeCommentPost_Validate()
        {
            ITraktEpisodeCommentPost episodeCommentPost = new TraktEpisodeCommentPost();

            // Comment = null
            Action act = () => episodeCommentPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Comment = less than five words
            episodeCommentPost.Comment = "one two three four";
            act.Should().Throw<TraktPostValidationException>();

            // Episode = null
            episodeCommentPost.Comment = "one two three four five";
            act.Should().Throw<TraktPostValidationException>();

            // Episode Ids = null
            episodeCommentPost.Episode = new TraktEpisode();
            act.Should().Throw<TraktPostValidationException>();

            // Episode IDs have no valid id
            episodeCommentPost.Episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds()
            };
            act.Should().Throw<TraktPostValidationException>();

            // valid
            episodeCommentPost.Episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds { Trakt = 1 }
            };
            act.Should().NotThrow();
        }
    }
}
