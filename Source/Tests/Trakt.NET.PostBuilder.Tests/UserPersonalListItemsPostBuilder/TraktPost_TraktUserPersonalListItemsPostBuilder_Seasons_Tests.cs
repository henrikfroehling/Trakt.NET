namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeason_ITraktSeason()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_ITraktSeason()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_ITraktSeasonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_SeasonWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_SeasonIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostSeason postSeason = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonsWithNotes_SeasonWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(new List<SeasonWithNotes>
                {
                    new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                    new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonsWithNotes_SeasonIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(new List<SeasonIdsWithNotes>
                {
                    new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostSeason postSeason1 = userPersonalListItemsPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostSeason postSeason2 = userPersonalListItemsPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }
    }
}
