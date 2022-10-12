namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ITraktShow()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ITraktShowIds()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ShowWithNotes()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ShowIdsWithNotes()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRecommendationsPostShow postShow = syncRecommendationsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShows_ITraktShow()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow postShow1 = syncRecommendationsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktSyncRecommendationsPostShow postShow2 = syncRecommendationsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShows_ITraktShowIds()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow postShow1 = syncRecommendationsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktSyncRecommendationsPostShow postShow2 = syncRecommendationsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().BeNull();

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowsWithNotes_ShowWithNotes()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(new List<ShowWithNotes>
                {
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow postShow1 = syncRecommendationsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncRecommendationsPostShow postShow2 = syncRecommendationsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowsWithNotes_ShowIdsWithNotes()
        {
            ITraktSyncRecommendationsPost syncRecommendationsPost = TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(new List<ShowIdsWithNotes>
                {
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncRecommendationsPost.Should().NotBeNull();
            syncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow postShow1 = syncRecommendationsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncRecommendationsPostShow postShow2 = syncRecommendationsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncRecommendationsPost.Movies.Should().BeNull();
        }
    }
}
