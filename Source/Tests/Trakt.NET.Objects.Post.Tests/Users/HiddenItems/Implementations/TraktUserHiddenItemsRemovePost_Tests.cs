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
    public class TraktUserHiddenItemsRemovePost_Tests
    {
        [Fact]
        public void Test_TraktHiddenItemsRemovePost_Validate()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = new TraktUserHiddenItemsRemovePost();

            // movies = null, shows = null, seasons = null, users = null
            Action act = () => userHiddenItemsRemovePost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, seasons = null, users = null
            userHiddenItemsRemovePost.Movies = new List<ITraktUserHiddenItemsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = null, users = null
            userHiddenItemsRemovePost.Shows = new List<ITraktUserHiddenItemsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, users = null
            userHiddenItemsRemovePost.Seasons = new List<ITraktUserHiddenItemsPostSeason>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, seasons = empty, users = empty
            userHiddenItemsRemovePost.Users = new List<ITraktUser>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, seasons = empty, users = empty
            (userHiddenItemsRemovePost.Movies as List<ITraktUserHiddenItemsPostMovie>).Add(new TraktUserHiddenItemsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, seasons = empty, users = empty
            (userHiddenItemsRemovePost.Movies as List<ITraktUserHiddenItemsPostMovie>).Clear();
            (userHiddenItemsRemovePost.Shows as List<ITraktUserHiddenItemsPostShow>).Add(new TraktUserHiddenItemsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons with at least one item, users = empty
            (userHiddenItemsRemovePost.Shows as List<ITraktUserHiddenItemsPostShow>).Clear();
            (userHiddenItemsRemovePost.Seasons as List<ITraktUserHiddenItemsPostSeason>).Add(new TraktUserHiddenItemsPostSeason());
            act.Should().NotThrow();

            // movies = empty, shows = empty, seasons = empty, users with at least one item
            (userHiddenItemsRemovePost.Seasons as List<ITraktUserHiddenItemsPostSeason>).Clear();
            (userHiddenItemsRemovePost.Users as List<ITraktUser>).Add(new TraktUser());
            act.Should().NotThrow();
        }
    }
}
