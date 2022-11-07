namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episode, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_EpisodeWithNotes_ArgumentExceptions()
        {
            EpisodeWithNotes episodeWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeWithNotes = new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeWithNotes = new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_EpisodeIdsWithNotes_ArgumentExceptions()
        {
            EpisodeIdsWithNotes episodeIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeIdsWithNotes = new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeIdsWithNotes = new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodes_ITraktEpisode_ArgumentExceptions()
        {
            List<ITraktEpisode> episodes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodes_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ITraktEpisodeIds> episodeIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodesWithNotes_EpisodeWithNotes_ArgumentExceptions()
        {
            List<EpisodeWithNotes> episodesWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodesWithNotes = new List<EpisodeWithNotes>
            {
                new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES),
                new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodesWithNotes = new List<EpisodeWithNotes>
            {
                new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES),
                new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodesWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodesWithNotes_EpisodeIdsWithNotes_ArgumentExceptions()
        {
            List<EpisodeIdsWithNotes> episodeIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeIdsWithNotes = new List<EpisodeIdsWithNotes>
            {
                new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            episodeIdsWithNotes = new List<EpisodeIdsWithNotes>
            {
                new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(episodeIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
