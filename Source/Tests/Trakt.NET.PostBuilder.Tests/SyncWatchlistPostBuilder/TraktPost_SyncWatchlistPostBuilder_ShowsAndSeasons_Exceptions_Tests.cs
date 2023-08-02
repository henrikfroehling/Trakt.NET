namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
            
            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, default(PostSeasons))
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, default(IEnumerable<int>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, default(PostSeasons))
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, default(IEnumerable<int>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasons_ShowAndSeasons_ArgumentExceptions()
        {
            ShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowAndSeasons_ShowIdsAndSeasons_ArgumentExceptions()
        {
            ShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotesAndSeasons_ShowWithNotesAndSeasons_ArgumentExceptions()
        {
            ShowWithNotesAndSeasons showWithNotesAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            var showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null);
            showWithNotesAndSeasons = new ShowWithNotesAndSeasons(showWithNotes, TraktPost_Tests_Common_Data.SHOW_SEASONS_1);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);
            showWithNotesAndSeasons = new ShowWithNotesAndSeasons(showWithNotes, TraktPost_Tests_Common_Data.SHOW_SEASONS_1);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotesAndSeasons_ShowIdsWithNotesAndSeasons_ArgumentExceptions()
        {
            ShowIdsWithNotesAndSeasons showIdsWithNotesAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            var showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null);
            showIdsWithNotesAndSeasons = new ShowIdsWithNotesAndSeasons(showIdsWithNotes, TraktPost_Tests_Common_Data.SHOW_SEASONS_1);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);
            showIdsWithNotesAndSeasons = new ShowIdsWithNotesAndSeasons(showIdsWithNotes, TraktPost_Tests_Common_Data.SHOW_SEASONS_1);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsAndSeasons_ShowAndSeasons_ArgumentExceptions()
        {
            List<ShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsAndSeasons_ShowIdsAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotesAndSeasons_ShowWithNotesAndSeasons_ArgumentExceptions()
        {
            List<ShowWithNotesAndSeasons> showsWithNotesAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            var showWithNotes1 = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES);
            var showWithNotes2 = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, null);

            showsWithNotesAndSeasons = new List<ShowWithNotesAndSeasons>
            {
                new ShowWithNotesAndSeasons(showWithNotes1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                new ShowWithNotesAndSeasons(showWithNotes2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes2 = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            showsWithNotesAndSeasons = new List<ShowWithNotesAndSeasons>
            {
                new ShowWithNotesAndSeasons(showWithNotes1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                new ShowWithNotesAndSeasons(showWithNotes2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotesAndSeasons_ShowIdsWithNotesAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsWithNotesAndSeasons> showIdsWithNotesAndSeasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            var showIdsWithNotes1 = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES);
            var showIdsWithNotes2 = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, null);

            showIdsWithNotesAndSeasons = new List<ShowIdsWithNotesAndSeasons>
            {
                new ShowIdsWithNotesAndSeasons(showIdsWithNotes1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                new ShowIdsWithNotesAndSeasons(showIdsWithNotes2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes2 = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            showIdsWithNotesAndSeasons = new List<ShowIdsWithNotesAndSeasons>
            {
                new ShowIdsWithNotesAndSeasons(showIdsWithNotes1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                new ShowIdsWithNotesAndSeasons(showIdsWithNotes2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotesAndSeasons(showIdsWithNotesAndSeasons)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
