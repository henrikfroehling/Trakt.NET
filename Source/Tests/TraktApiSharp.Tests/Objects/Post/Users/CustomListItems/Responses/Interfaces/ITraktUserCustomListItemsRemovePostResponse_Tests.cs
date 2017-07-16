namespace TraktApiSharp.Tests.Objects.Post.Users.CustomListItems.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using Xunit;

    [Category("Objects.Post.Users.CustomListItems.Responses.Interfaces")]
    public class ITraktUserCustomListItemsRemovePostResponse_Tests
    {
        [Fact]
        public void Test_ITraktUserCustomListItemsRemovePostResponse_Is_Interface()
        {
            typeof(ITraktUserCustomListItemsRemovePostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsRemovePostResponse_Has_Deleted_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsRemovePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Deleted");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserCustomListItemsPostResponseGroup));
        }

        [Fact]
        public void Test_ITraktUserCustomListItemsRemovePostResponse_Has_NotFound_Property()
        {
            var propertyInfo = typeof(ITraktUserCustomListItemsRemovePostResponse).GetProperties().FirstOrDefault(p => p.Name == "NotFound");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserCustomListItemsPostResponseNotFoundGroup));
        }
    }
}
