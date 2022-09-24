namespace TraktNet.Objects.Post.Tests.Users.HiddenItems.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("Objects.Post.Users.HiddenItems.Implementations")]
    public class TraktUserHiddenItemsPost_Tests
    {
        [Fact]
        public void Test_TraktHiddenItemsPost_Validate()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = new TraktUserHiddenItemsPost();

            // movies = null, shows = null, seasons = null, users = null
            Action act = () => userHiddenItemsPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, seasons = null, users = null
            userHiddenItemsPost.Movies = new List<ITraktUserHiddenItemsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = null, users = null
            userHiddenItemsPost.Shows = new List<ITraktUserHiddenItemsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, users = null
            userHiddenItemsPost.Seasons = new List<ITraktUserHiddenItemsPostSeason>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, users = empty
            userHiddenItemsPost.Users = new List<ITraktUser>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, seasons = empty, users = empty
            (userHiddenItemsPost.Movies as List<ITraktUserHiddenItemsPostMovie>).Add(new TraktUserHiddenItemsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, users = empty
            (userHiddenItemsPost.Movies as List<ITraktUserHiddenItemsPostMovie>).Clear();
            (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>).Add(new TraktUserHiddenItemsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, users = empty
            (userHiddenItemsPost.Shows as List<ITraktUserHiddenItemsPostShow>).Clear();
            (userHiddenItemsPost.Seasons as List<ITraktUserHiddenItemsPostSeason>).Add(new TraktUserHiddenItemsPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, users with at least one item
            (userHiddenItemsPost.Seasons as List<ITraktUserHiddenItemsPostSeason>).Clear();
            (userHiddenItemsPost.Users as List<ITraktUser>).Add(new TraktUser());
            act.Should().NotThrow();
        }
    }
}
