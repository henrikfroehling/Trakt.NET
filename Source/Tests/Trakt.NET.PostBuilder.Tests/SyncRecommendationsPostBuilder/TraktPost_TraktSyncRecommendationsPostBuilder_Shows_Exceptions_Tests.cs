namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(show, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            ShowWithNotes showWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, null);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showWithNotes = new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            ShowIdsWithNotes showIdsWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, null);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowsWithNotes_ShowWithNotes_ArgumentExceptions()
        {
            List<ShowWithNotes> showsWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, null)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showsWithNotes = new List<ShowWithNotes>
            {
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithShowsWithNotes_ShowIdsWithNotes_ArgumentExceptions()
        {
            List<ShowIdsWithNotes> showIdsWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, null)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            showIdsWithNotes = new List<ShowIdsWithNotes>
            {
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithShowsWithNotes(showIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
