namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }
    }
}
