namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserLikeItem_Tests
    {
        [Fact]
        public void Test_ITraktUserLikeItem_Is_Interface()
        {
            typeof(ITraktUserLikeItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserLikeItem_Has_LikedAt_Property()
        {
            var propertyInfo = typeof(ITraktUserLikeItem).GetProperties().FirstOrDefault(p => p.Name == "LikedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserLikeItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktUserLikeItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktUserLikeType));
        }

        [Fact]
        public void Test_ITraktUserLikeItem_Has_Comment_Property()
        {
            var propertyInfo = typeof(ITraktUserLikeItem).GetProperties().FirstOrDefault(p => p.Name == "Comment");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktComment));
        }

        [Fact]
        public void Test_ITraktUserLikeItem_Has_List_Property()
        {
            var propertyInfo = typeof(ITraktUserLikeItem).GetProperties().FirstOrDefault(p => p.Name == "List");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktList));
        }
    }
}
