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
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(show, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            ShowWithNotes showWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            ShowIdsWithNotes showIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            List<ShowWithNotes> showsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithShowsWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            List<ShowIdsWithNotes> showIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
