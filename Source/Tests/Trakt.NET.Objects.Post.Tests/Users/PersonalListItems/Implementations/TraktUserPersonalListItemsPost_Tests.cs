namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("Objects.Post.Users.PersonalListItems.Implementations")]
    public class TraktUserPersonalListItemsPost_Tests
    {
        [Fact]
        public void Test_TraktPersonalListItemsPost_Validate()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = new TraktUserPersonalListItemsPost();

            // movies = null, shows = null, seasons = null, episodes = null, people = null
            Action act = () => userPersonalListItemsPost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null, seasons = null, episodes = null, people = null
            userPersonalListItemsPost.Movies = new List<ITraktUserPersonalListItemsPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = null, episodes = null, people = null
            userPersonalListItemsPost.Shows = new List<ITraktUserPersonalListItemsPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = null, people = null
            userPersonalListItemsPost.Seasons = new List<ITraktUserPersonalListItemsPostSeason>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = null
            userPersonalListItemsPost.Episodes = new List<ITraktUserPersonalListItemsPostEpisode>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people = empty
            userPersonalListItemsPost.People = new List<ITraktUserPersonalListItemsPostPerson>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty, seasons = empty, episodes = empty, people = empty
            (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(new TraktUserPersonalListItemsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, episodes = empty, people = empty
            (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Clear();
            (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(new TraktUserPersonalListItemsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, episodes = empty, people = empty
            (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Clear();
            (userPersonalListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>).Add(new TraktUserPersonalListItemsPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes with at least one item, people = empty
            (userPersonalListItemsPost.Seasons as List<ITraktUserPersonalListItemsPostSeason>).Clear();
            (userPersonalListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>).Add(new TraktUserPersonalListItemsPostEpisode());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, episodes = empty, people with at least one item
            (userPersonalListItemsPost.Episodes as List<ITraktUserPersonalListItemsPostEpisode>).Clear();
            (userPersonalListItemsPost.People as List<ITraktUserPersonalListItemsPostPerson>).Add(new TraktUserPersonalListItemsPostPerson());
            act.Should().NotThrow();
        }
    }
}
