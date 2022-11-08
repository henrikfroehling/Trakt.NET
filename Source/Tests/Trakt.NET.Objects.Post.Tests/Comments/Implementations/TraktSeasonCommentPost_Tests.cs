﻿namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("Objects.Post.Comments.Implementations")]
    public class TraktSeasonCommentPost_Tests
    {
        [Fact]
        public void Test_TraktSeasonCommentPost_Validate()
        {
            ITraktSeasonCommentPost seasonCommentPost = new TraktSeasonCommentPost();

            // Comment = null
            Action act = () => seasonCommentPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Comment = less than five words
            seasonCommentPost.Comment = "one two three four";
            act.Should().Throw<TraktPostValidationException>();

            // Season = null
            seasonCommentPost.Comment = "one two three four five";
            act.Should().Throw<TraktPostValidationException>();

            // Season Ids = null
            seasonCommentPost.Season = new TraktSeason();
            act.Should().Throw<TraktPostValidationException>();

            // Season IDs have no valid id
            seasonCommentPost.Season = new TraktSeason
            {
                Ids = new TraktSeasonIds()
            };
            act.Should().Throw<TraktPostValidationException>();

            // valid
            seasonCommentPost.Season = new TraktSeason
            {
                Ids = new TraktSeasonIds { Trakt = 1 }
            };
            act.Should().NotThrow();
        }
    }
}
