namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Interfaces")]
    public class ITraktUserCustomListItemsPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponse_Is_Interface()
        {
            typeof(ITraktUserCustomListItemsPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponse_Has_Added_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Added");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserCustomListItemsPostResponseGroup));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponse_Has_Existing_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Existing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserCustomListItemsPostResponseGroup));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsPostResponse_Has_NotFound_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsPostResponse).GetProperties().FirstOrDefault(p => p.Name == "NotFound");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup));
        }
    }
}
