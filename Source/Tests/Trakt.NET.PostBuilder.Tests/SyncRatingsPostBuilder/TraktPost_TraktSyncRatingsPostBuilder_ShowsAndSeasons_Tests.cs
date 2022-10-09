namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowAndSeasons_ITraktShow()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowAndSeasons_ITraktShowIds()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1)
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowAndSeasons_RatingsShowAndSeasons()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowAndSeasons(new RatingsShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1,
                                                              TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowAndSeasons_RatingsShowIdsAndSeasons()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowAndSeasons(new RatingsShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                                  TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1))
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostShow postShow = syncRatingsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Rating.Should().BeNull();
            postShow.RatedAt.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsAndSeasons_RatingsShowAndSeasons()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowsAndSeasons(new List<RatingsShowAndSeasons>
                {
                    new RatingsShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1,
                                              TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1),
                    new RatingsShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_2,
                                              TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_2)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Rating.Should().BeNull();
            postShow1.RatedAt.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Rating.Should().BeNull();
            postShow2.RatedAt.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithShowsAndSeasons_RatedShowIdsAndSeasons()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost()
                .WithShowsAndSeasons(new List<RatingsShowIdsAndSeasons>
                {
                    new RatingsShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                 TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_1),
                    new RatingsShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2,
                                                 TraktPost_Tests_Common_Data.RATINGS_SHOW_SEASONS_2)
                })
                .Build();

            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktSyncRatingsPostShow postShow1 = syncRatingsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Rating.Should().BeNull();
            postShow1.RatedAt.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(4);

            ITraktSyncRatingsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            postShowSeasons[2].Number.Should().Be(3);
            postShowSeasons[2].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[2].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);
            postShowSeasons[2].Episodes.Should().BeNull();

            postShowSeasons[3].Number.Should().Be(4);
            postShowSeasons[3].Rating.Should().BeNull();
            postShowSeasons[3].RatedAt.Should().BeNull();
            postShowSeasons[3].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[3].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktSyncRatingsPostShow postShow2 = syncRatingsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Rating.Should().BeNull();
            postShow2.RatedAt.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            postShowSeasons[0].RatedAt.Should().BeNull();
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Rating.Should().BeNull();
            postShowSeasons[1].RatedAt.Should().BeNull();
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[0].RatedAt.Should().BeNull();

            episodes[1].Number.Should().Be(2);
            episodes[1].Rating.Should().Be((int)TraktPost_Tests_Common_Data.RATING);
            episodes[1].RatedAt.Should().Be(TraktPost_Tests_Common_Data.RATED_AT);

            syncRatingsPost.Movies.Should().BeNull();
            syncRatingsPost.Seasons.Should().BeNull();
            syncRatingsPost.Episodes.Should().BeNull();
        }
    }
}
