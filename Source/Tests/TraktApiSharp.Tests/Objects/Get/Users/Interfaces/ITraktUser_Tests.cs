namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUser_Tests
    {
        [Fact]
        public void Test_ITraktUser_Is_Interface()
        {
            typeof(ITraktUser).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUser_Has_Username_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Username");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktUser_Has_IsPrivate_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "IsPrivate");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktUser_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserIds));
        }

        [Fact]
        public void Test_ITraktUser_Has_Name_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Name");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktUser_Has_IsVIP_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "IsVIP");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktUser_Has_IsVIP_EP_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "IsVIP_EP");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktUser_Has_JoinedAt_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "JoinedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUser_Has_Location_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Location");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktUser_Has_About_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "About");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktUser_Has_Gender_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Gender");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktUser_Has_Age_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Age");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUser_Has_Images_Property()
        {
            var propertyInfo = typeof(ITraktUser).GetProperties().FirstOrDefault(p => p.Name == "Images");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserImages));
        }
    }
}
