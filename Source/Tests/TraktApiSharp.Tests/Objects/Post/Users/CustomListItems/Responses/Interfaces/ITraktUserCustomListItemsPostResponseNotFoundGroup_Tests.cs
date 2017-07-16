namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Interfaces")]
    public class ITraktUserCustomListItemsPostResponseNotFoundGroup_Tests
    {
        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Is_Interface()
        {
            typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Has_Movies_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).GetProperties().FirstOrDefault(p => p.Name == "Movies");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPostResponseNotFoundMovie>));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Has_Shows_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).GetProperties().FirstOrDefault(p => p.Name == "Shows");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPostResponseNotFoundShow>));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPostResponseNotFoundSeason>));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPostResponseNotFoundEpisode>));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseNotFoundGroup_Has_People_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup).GetProperties().FirstOrDefault(p => p.Name == "People");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktPostResponseNotFoundPerson>));
        }
    }
}
