namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("Objects.Post.Users.PersonalListItems.Implementations")]
    public class TraktUserPersonalListItemsRemovePost_Tests
    {
        [Fact]
        public void Test_TraktPersonalListItemsRemovePost_Validate()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = new TraktUserPersonalListItemsRemovePost();

            // movies = null, shows = null, seasons = null, episodes = null, people = null
            Action act = () => userPersonalListItemsRemovePost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, seasons = null, episodes = null, people = null
            userPersonalListItemsRemovePost.Movies = new List<ITraktUserPersonalListItemsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, people = null
            userPersonalListItemsRemovePost.Shows = new List<ITraktUserPersonalListItemsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, people = null
            userPersonalListItemsRemovePost.Seasons = new List<ITraktUserPersonalListItemsPostSeason>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = null
            userPersonalListItemsRemovePost.Episodes = new List<ITraktUserPersonalListItemsPostEpisode>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsRemovePost.People = new List<ITraktUserPersonalListItemsPostPerson>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, people = empty
            (userPersonalListItemsRemovePost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(new TraktUserPersonalListItemsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, people = empty
            (userPersonalListItemsRemovePost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Clear();
            (userPersonalListItemsRemovePost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(new TraktUserPersonalListItemsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, people = empty
            (userPersonalListItemsRemovePost.Shows as List<ITraktUserPersonalListItemsPostShow>).Clear();
            (userPersonalListItemsRemovePost.Seasons as List<ITraktUserPersonalListItemsPostSeason>).Add(new TraktUserPersonalListItemsPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, people = empty
            (userPersonalListItemsRemovePost.Seasons as List<ITraktUserPersonalListItemsPostSeason>).Clear();
            (userPersonalListItemsRemovePost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>).Add(new TraktUserPersonalListItemsPostEpisode());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people with at least one item
            (userPersonalListItemsRemovePost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>).Clear();
            (userPersonalListItemsRemovePost.People as List<ITraktUserPersonalListItemsPostPerson>).Add(new TraktUserPersonalListItemsPostPerson());
            act.Should().NotThrow();
        }
    }
}
