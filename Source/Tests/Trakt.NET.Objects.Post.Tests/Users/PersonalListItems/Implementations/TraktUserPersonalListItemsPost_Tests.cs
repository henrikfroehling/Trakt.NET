namespace TraktNet.Objects.Post.Tests.Users.PersonalListItems.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("Objects.Post.Users.PersonalListItems.Implementations")]
    public class TraktUserPersonalListItemsPost_Tests
    {
        [Fact]
        public void Test_TraktPersonalListItemsPost_Validate()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = new TraktUserPersonalListItemsPost();

            // movies = null, shows = null, people = null
            Action act = () => userPersonalListItemsPost.Validate();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = null, people = null
            userPersonalListItemsPost.Movies = new List<ITraktUserPersonalListItemsPostMovie>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, people = null
            userPersonalListItemsPost.Shows = new List<ITraktUserPersonalListItemsPostShow>();
            act.Should().Throw<ArgumentException>();

            // movies = empty, shows = empty, people = empty
            userPersonalListItemsPost.People = new List<ITraktPerson>();
            act.Should().Throw<ArgumentException>();

            // movies with at least one item, shows = empty, people = empty
            (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Add(new TraktUserPersonalListItemsPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item, people = empty
            (userPersonalListItemsPost.Movies as List<ITraktUserPersonalListItemsPostMovie>).Clear();
            (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Add(new TraktUserPersonalListItemsPostShow());
            act.Should().NotThrow();

            // movies = empty, shows = empty, people with at least one item
            (userPersonalListItemsPost.Shows as List<ITraktUserPersonalListItemsPostShow>).Clear();
            (userPersonalListItemsPost.People as List<ITraktPerson>).Add(new TraktPerson());
            act.Should().NotThrow();
        }
    }
}
