namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Implementations")]
    public class TraktSyncRecommendationsRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncRecommendationsRemovePost_Validate()
        {
            ITraktSyncRecommendationsRemovePost syncRecommendationsRemovePost = new TraktSyncRecommendationsRemovePost();

            // movies = null, shows = null
            Action act = () => syncRecommendationsRemovePost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null
            syncRecommendationsRemovePost.Movies = new List<ITraktSyncRecommendationsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty
            syncRecommendationsRemovePost.Shows = new List<ITraktSyncRecommendationsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty
            (syncRecommendationsRemovePost.Movies as List<ITraktSyncRecommendationsPostMovie>).Add(new TraktSyncRecommendationsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item
            (syncRecommendationsRemovePost.Movies as List<ITraktSyncRecommendationsPostMovie>).Clear();
            (syncRecommendationsRemovePost.Shows as List<ITraktSyncRecommendationsPostShow>).Add(new TraktSyncRecommendationsPostShow());
            act.Should().NotThrow();
        }
    }
}
