namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ITraktShow()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ITraktShowIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ShowWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ShowIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostShow postShow = syncWatchlistPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShows_ITraktShow()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShows_ITraktShowIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotes_ShowWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(new List<ShowWithNotes>
                {
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotes_ShowIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(new List<ShowIdsWithNotes>
                {
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostShow postShow1 = syncWatchlistPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostShow postShow2 = syncWatchlistPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
            syncWatchlistPost.Episodes.Should().BeNull();
        }
    }
}
