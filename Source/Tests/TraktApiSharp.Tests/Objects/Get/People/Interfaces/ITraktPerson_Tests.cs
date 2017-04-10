namespace TraktApiSharp.Tests.Objects.Get.People.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using Xunit;

    [Category("Objects.Get.People.Interfaces")]
    public class ITraktPerson_Tests
    {
        [Fact]
        public void Test_ITraktPerson_Is_Interface()
        {
            typeof(ITraktPerson).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPerson_Has_Name_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Name");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPersonIds));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Biography_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Biography");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Birthday_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Birthday");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Death_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Death");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Age_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Age");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(int));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Birthplace_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Birthplace");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPerson_Has_Homepage_Property()
        {
            var propertyInfo = typeof(ITraktPerson).GetProperties().FirstOrDefault(p => p.Name == "Homepage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
