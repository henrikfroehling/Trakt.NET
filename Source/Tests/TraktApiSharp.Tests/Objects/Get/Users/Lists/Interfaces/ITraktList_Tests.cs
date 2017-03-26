namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Interfaces")]
    public class ITraktList_Tests
    {
        [Fact]
        public void Test_ITraktList_Is_Interface()
        {
            typeof(ITraktList).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktList_Has_Name_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "Name");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktList_Has_Description_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "Description");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktList_Has_Privacy_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "Privacy");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktAccessScope));
        }

        [Fact]
        public void Test_ITraktList_Has_DisplayNumbers_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "DisplayNumbers");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktList_Has_AllowComments_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "AllowComments");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktList_Has_SortBy_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "SortBy");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktList_Has_SortHow_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "SortHow");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktList_Has_CreatedAt_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "CreatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktList_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktList_Has_ItemCount_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "ItemCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktList_Has_CommentCount_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "CommentCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktList_Has_Likes_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "Likes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktList_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktListIds));
        }

        [Fact]
        public void Test_ITraktList_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktList).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
