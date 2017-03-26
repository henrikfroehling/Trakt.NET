namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktComment_Tests
    {
        [Fact]
        public void Test_ITraktComment_Is_Interface()
        {
            typeof(ITraktComment).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktComment_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktComment_Has_ParentId_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "ParentId");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktComment_Has_CreatedAt_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "CreatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime));
        }

        [Fact]
        public void Test_ITraktComment_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktComment_Has_Comment_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Comment");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktComment_Has_Spoiler_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Spoiler");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [Fact]
        public void Test_ITraktComment_Has_Review_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Review");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [Fact]
        public void Test_ITraktComment_Has_Replies_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Replies");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktComment_Has_Likes_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "Likes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktComment_Has_UserRating_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "UserRating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktComment_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktComment).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
