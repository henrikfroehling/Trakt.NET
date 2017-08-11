namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Interfaces")]
    public class ITraktUserCustomListItemsPostResponseGroup_Tests
    {
        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Is_Interface()
        {
            typeof(ITraktUserCustomListItemsPostResponseGroup).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Has_Movies_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseGroup).GetProperties().FirstOrDefault(p => p.Name == "Movies");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Has_Shows_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseGroup).GetProperties().FirstOrDefault(p => p.Name == "Shows");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseGroup).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseGroup).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponseGroup_Has_People_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponseGroup).GetProperties().FirstOrDefault(p => p.Name == "People");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
