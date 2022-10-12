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
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_ITraktEpisode()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_ITraktEpisodeIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_EpisodeWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodeWithNotes_EpisodeIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodeWithNotes(new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostEpisode postEpisode = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostEpisode postEpisode1 = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostEpisode postEpisode2 = userPersonalListItemsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODE_IDS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostEpisode postEpisode1 = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostEpisode postEpisode2 = userPersonalListItemsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodesWithNotes_EpisodeWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(new List<EpisodeWithNotes>
                {
                    new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES),
                    new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostEpisode postEpisode1 = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostEpisode postEpisode2 = userPersonalListItemsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithEpisodesWithNotes_EpisodeIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithEpisodesWithNotes(new List<EpisodeIdsWithNotes>
                {
                    new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostEpisode postEpisode1 = userPersonalListItemsPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostEpisode postEpisode2 = userPersonalListItemsPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }
    }
}
