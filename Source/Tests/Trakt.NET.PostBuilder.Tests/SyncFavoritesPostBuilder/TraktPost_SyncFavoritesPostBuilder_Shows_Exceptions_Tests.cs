namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowWithNotes_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(show, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowWithNotes_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            ShowWithNotes showWithNotes = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null);

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            ShowIdsWithNotes showIdsWithNotes = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null);

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowsWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            List<ShowWithNotes> showsWithNotes = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, null)
            };

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithShowsWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            List<ShowIdsWithNotes> showIdsWithNotes = null;

            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, null)
            };

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncFavoritesPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
