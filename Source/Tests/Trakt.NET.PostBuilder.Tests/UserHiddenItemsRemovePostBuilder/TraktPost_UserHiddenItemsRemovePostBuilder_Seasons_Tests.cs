namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostSeason postSeason = userHiddenItemsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostSeason postSeason = userHiddenItemsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostSeason postSeason1 = userHiddenItemsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            ITraktUserHiddenItemsPostSeason postSeason2 = userHiddenItemsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostSeason postSeason1 = userHiddenItemsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            ITraktUserHiddenItemsPostSeason postSeason2 = userHiddenItemsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }
    }
}
